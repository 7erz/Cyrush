using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int ranDrop;
    public static int ranVar;
    public static int item1Rate = 10;
    public static int coinRate = 30;
    public static int coinValue = 1;
    Vector3 dir;
    float angle;
    public string enemyName;
    public int enemyScore;
    public float speed;
    public float health;
    public float xp;
    Transform target,runaway,ctt,enemyWays;   //ctt = 코인 트레일 타겟
    public float maxShotDelay;
    public float curShotDelay;
    bool isInviPass;
    // public GameObject bulletObjA;
    // public GameObject bulletObjB;

    SpriteRenderer spriteRenderer;  //스프라이트 2개 피격이벤트용 (나중에 피격이벤트 대신 스테이지마다 스프라이트가 변경되는 식으로 로직을 고칠것, OnHit은 스프라이트 대체형식이 아닌 컬러로 대체할 것)
    Rigidbody2D rigid;      //속도 관리
    PlayerMove playerStat;
    GameManager gameManager;
    public GameObject player;
    public GameObject itemCoin;
    public GameObject coinTrail;
    public ObjectManager objectManager;

    //초기화
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start(){
        playerStat = player.GetComponent<PlayerMove>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        runaway = GameObject.FindGameObjectWithTag("RunAway").GetComponent<Transform>();
        ctt = GameObject.FindGameObjectWithTag("CoinTrailTarget").GetComponent<Transform>();
        enemyWays = GameObject.FindGameObjectWithTag("EnemyWays").GetComponent<Transform>();
        gameManager = GetComponent<GameManager>();
        dir = target.transform.position - transform.position;
        dir.y = 0f;
        angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

    }
    void OnEnable() {   //컴포넌트 활성화 될떄 호출되는 생명주기함수
        isInviPass = true;
        switch(enemyName){
            case "C":
                health = 1 * GameManager.healthMultipler;
                xp = 1 * GameManager.xpMultipler;
                enemyScore = 100 * (int)GameManager.scoreMultipler;
                speed = 8 * GameManager.speedMultipler;
                break;
            case "S":
                health = 2 * GameManager.healthMultipler;
                xp = 3 * GameManager.xpMultipler;
                enemyScore = 300 * (int)GameManager.scoreMultipler;
                speed = 5 * GameManager.speedMultipler;
                maxShotDelay = 8 * GameManager.maxShotDelayMultipler;
                break;
            case "T":
                health = 10 * GameManager.healthMultipler;
                xp = 8 * GameManager.xpMultipler;
                enemyScore = 500 * (int)GameManager.scoreMultipler;
                speed = 3 * GameManager.speedMultipler;
                maxShotDelay = 15 * GameManager.maxShotDelayMultipler;
                break;
        }
    }
    

    //데미지 계산
    void OnHit(float dmg){

        if(health <= 0)
            return;

        health -= dmg;  //차감
        spriteRenderer.color = new Color(1,1,1,0.5f); //피격시 색[1] 강조
        Invoke("ReturnSprites",0.1f);   //시간차 함수로 반복
        if(health <= 0){    //체력이 0일때
            // PlayerMove playerStat = player.GetComponent<PlayerMove>();
            playerStat.score += enemyScore;    //유니티 내에서 받아온걸 playermove스코어에 추가
            playerStat.curExp += xp;
            //드랍율
            ranVar = Random.Range(0,100);
            ranDrop = Random.Range(0,100);
            if(ranDrop < playerStat.dropRateTotal ){
                // Debug.Log("No Item");       //ranDrop < 10  은 90퍼 확률로 아이템이 없음
            }else if(ranDrop < 100){        //남은 확률 아이템
                // Debug.Log("드랍넘버" + ranVar + "드랍한 것" + ranDrop);
                if(PlayerMove.isDead == false){
                    if(ranVar < coinRate){
                        // Debug.Log("Coin");
                        itemCoin = objectManager.MakeObj("Coin"); 
                        itemCoin.transform.position = transform.position;

                        DisapearCoin();
                        Invoke("deleteCoin", 2f);
                    }else if(ranVar < 100){
                        // Debug.Log("마지막 추후 추가될 아이템");
                    }
                }
            }
            gameObject.SetActive(false);   //파괴
        }
    }

    void ReturnSprites(){
        spriteRenderer.color = new Color(255,255,255);     //퍙상시 색[0]
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "BorderBullet")
            gameObject.SetActive(false);    //벽에 피격시 파괴
        else if(collision.gameObject.tag == "PlayerBullet"){
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();    //불릿 스크립트 가져옴
            OnHit(bullet.dmg * Bullet.bonusDmg);  //플레이어 총알 피격시 데미지입력
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Player"){
            gameObject.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "InvisibleWall"){
            isInviPass = false;
        }
    }

    void Update()
    {
        moveControl();
        Fire();
        Reload();
    }
    void boolisGO(){
        if(isInviPass == true){
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }else{
            transform.position = Vector2.MoveTowards(transform.position,enemyWays.position - new Vector3 (-10,0,0),speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void moveControl(){
        if(PlayerMove.isDead == false){
            boolisGO();
            //인식범위 넣어서 해결
        }else
            transform.position = Vector2.MoveTowards(transform.position,runaway.position,speed * 2 * Time.deltaTime);
    }

    void Fire(){
        //발사 조건
        if(curShotDelay < maxShotDelay)
            return;
            switch(enemyName){
                case "C":
                    if(PlayerMove.isDead == false){
                        // GameObject bulletC = objectManager.MakeObj("EnemyBulletC");
                        // bulletC.transform.position = transform.position;

                        // Rigidbody2D rigid = bulletC.GetComponent<Rigidbody2D>();

                        // Vector3 dirVec = player.transform.position - transform.position;
                        // rigid.AddForce(dirVec.normalized * 15, ForceMode2D.Impulse);
                    }
                    break;
                case "S":
                    if(PlayerMove.isDead == false){
                        GameObject bulletS = objectManager.MakeObj("EnemyBulletC");
                        bulletS.transform.position = transform.position;

                        Rigidbody2D rigidS = bulletS.GetComponent<Rigidbody2D>();

                        Vector3 dirVecS = player.transform.position - transform.position;
                        rigidS.AddForce(dirVecS.normalized * 8, ForceMode2D.Impulse);
                    }
                    break;
                case "T":
                    if(PlayerMove.isDead == false){
                        GameObject bulletT = objectManager.MakeObj("EnemyBulletC");
                        bulletT.transform.position = transform.position;

                        Rigidbody2D rigidT = bulletT.GetComponent<Rigidbody2D>();

                        Vector3 dirVecT = player.transform.position - transform.position;
                        rigidT.AddForce(dirVecT.normalized * 5, ForceMode2D.Impulse);
                    }
                    break;
            }
        curShotDelay = 0;
    }

    void Reload(){
        curShotDelay += Time.deltaTime;
    }

    public void DisapearCoin(){
        Invoke("DisCoinEXE", 0.5f);
    }

    public void DisCoinEXE(){
        coinTrail = objectManager.MakeObj("CoinTrail");
        coinTrail.transform.position = itemCoin.transform.position;
        // Debug.Log("생성된 위치"+coinTrail.transform.position);
        itemCoin.gameObject.SetActive(false);
        Rigidbody2D trailRigid = coinTrail.GetComponent<Rigidbody2D>();

        Vector3 trailDirVec = ctt.transform.position - transform.position;
        trailRigid.AddForce(trailDirVec.normalized * 6, ForceMode2D.Impulse);
        Invoke("getCoin",0.2f);
    }
    
    void deleteCoin(){
        itemCoin.SetActive(false);
    }

    void getCoin(){
        //PlayerMove playerCoin = player.GetComponent<PlayerMove>();
        PlayerMove.coin += coinValue;
    }
}
