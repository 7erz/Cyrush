using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Vector3 dir;
    float angle;

    int multipler;
    float times;
    public float health;
    public string bossName;
    public float bossScore;
    public float bossXp;
    public float speed = 2f;
    public float maxShotDelay;
    public float curShotDelay;
    public bool bossDead;

    public int patternIndex;
    public int curPatCount;
    public int[] maxPatCount;

    SpriteRenderer spriteRenderer;
    Transform target,ctt,FBossT;
    PlayerMove playerStat;
    GameManager gameManager;
    public GameObject itemCoin;
    public GameObject coinTrail;
    public GameObject player;
    public ObjectManager objectManager;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        playerStat = player.GetComponent<PlayerMove>();
        gameManager = GetComponent<GameManager>();
        target = GameObject.FindGameObjectWithTag("BossTarget").GetComponent<Transform>();
        ctt = GameObject.FindGameObjectWithTag("CoinTrailTarget").GetComponent<Transform>();
        FBossT = GameObject.FindGameObjectWithTag("FinalBossTarget").GetComponent<Transform>();
        dir = target.transform.position - transform.position;
        dir.y = 0f;
        angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
    }

    void OnEnable(){
        switch(bossName){
            case "A":
            bossDead = false;
            health = 50 * GameManager.bossMultipler;
            bossScore = 10000 * GameManager.bossMultipler;
            bossXp = 20 * GameManager.bossMultipler;
            Invoke("DoA",2);
            break;
            case "B":
            bossDead = false;
            health = 60 * GameManager.bossMultipler;
            bossScore = 11000 * GameManager.bossMultipler;
            bossXp = 21 * GameManager.bossMultipler;
            Invoke("DoB",2);    //나중에 이 부분은 삭제
            break;
            case "C":
            bossDead = false;
            health = 70 * GameManager.bossMultipler;
            bossScore = 12000 * GameManager.bossMultipler;
            bossXp = 22 * GameManager.bossMultipler;
            Invoke("DoC",2);    //나중에 이 부분은 삭제
            break;
            case "F":
            Invoke("DoF",3);
            break;
        }
    }
    void Update()
    {
        times += Time.deltaTime;
        BossMoveControl();
    }
    
    void OnBossHit(float dmg){
        if(health <= 0)
            return;

        health -= dmg;
        spriteRenderer.color = new Color(1,1,1,0.5f);
        Invoke("ReturnBossSprites",0.1f);
        if(health <= 0){
            playerStat.score += (int)bossScore;
            playerStat.curExp += bossXp;
            PlayerMove.coin += 5 * (int)GameManager.bossMultipler;
            GameManager.curBoss = false;
            gameObject.SetActive(false);
        }
    }
    void ReturnBossSprites(){
        spriteRenderer.color = new Color(255,255,255);     //퍙상시 색[0]
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "PlayerBullet"){
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();    //불릿 스크립트 가져옴
            OnBossHit(bullet.dmg * Bullet.bonusDmg);  //플레이어 총알 피격시 데미지입력
            collision.gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "FinalBossTarget"){
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "Player"){
            PlayerMove.isDead = true;
        }
    }

    void getCoin(){
        PlayerMove.coin += Enemy.coinValue;
    }
    void BossMoveControl(){
        if((int)times < 21){
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
        }else{
            transform.position = Vector2.MoveTowards(transform.position,FBossT.position,3 * Time.deltaTime);
        }
    }

    void DoA(){
        if(!gameObject.activeSelf)
            return;

        Invoke("AThink",2);
    }

    void AThink(){
        patternIndex = patternIndex == 1 ? 0 : patternIndex + 1; //현재 패턴이 패턴 갯수를 넘기면 0으로 돌아오는 로직
        curPatCount = 0;    //패턴이 바뀔때마다 실행 횟수 변수를 초기화함

        switch(patternIndex){
            case 0:
                AFireTarget();
                break;
            case 1:
                AFireStr();
                break;
        }
    }
    void AFireTarget(){
        print("AFireTarget");
        BulletParticle TarA1 = GameObject.Find("ATar1").GetComponent<BulletParticle>();
        BulletParticle TarA2 = GameObject.Find("ATar2").GetComponent<BulletParticle>();
        TarA1.FireTarget();
        TarA2.FireTarget();
        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("AFireTarget",3.5f);
        else
            Invoke("AThink",2);
    }
    void AFireStr(){
        print("AfireStr");
        BulletParticle StrF1 = GameObject.Find("AStr1").GetComponent<BulletParticle>();
        BulletParticle StrF2 = GameObject.Find("AStr2").GetComponent<BulletParticle>();
        StrF1.FireStr();
        StrF2.FireStr();
        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("AFireStr",3.5f);
        else
            Invoke("AThink",2);
    }

    void DoB(){
        if(!gameObject.activeSelf)
            return;

        Invoke("BThink",2);
    }

    void BThink(){
        patternIndex = patternIndex == 1 ? 0 : patternIndex + 1; //현재 패턴이 패턴 갯수를 넘기면 0으로 돌아오는 로직
        curPatCount = 0;    //패턴이 바뀔때마다 실행 횟수 변수를 초기화함

        switch(patternIndex){
            case 0:
                BFireTarget();
                break;
            case 1:
                BFireAuto();
                break;
        }
    }
    void BFireTarget(){
        print("BFireTarget");
        BulletParticle TarB1 = GameObject.Find("BTar1").GetComponent<BulletParticle>();
        BulletParticle TarB2 = GameObject.Find("BTar2").GetComponent<BulletParticle>();
        BulletParticle TarB3 = GameObject.Find("BTar3").GetComponent<BulletParticle>();
        TarB1.FireTarget();
        TarB2.FireTarget();
        TarB3.FireTarget();
        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("BFireTarget",3.5f);
        else
            Invoke("BThink",2);
    }
    void BFireAuto(){
        print("BFireAuto");
        BulletParticle AutoFB1 = GameObject.Find("BTri1").GetComponent<BulletParticle>();
        BulletParticle AutoFB2 = GameObject.Find("BTri2").GetComponent<BulletParticle>();
        BulletParticle AutoFB3 = GameObject.Find("BTri3").GetComponent<BulletParticle>();
        AutoFB1.FireAuto();
        AutoFB2.FireAuto();
        AutoFB3.FireAuto();   

        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("BFireAuto",3.5f);
        else
            Invoke("BThink",2);
    }
    void DoC(){
        if(!gameObject.activeSelf)
            return;

        Invoke("CThink",2);
    }
    void CThink(){
        patternIndex = patternIndex == 1 ? 0 : patternIndex + 1; //현재 패턴이 패턴 갯수를 넘기면 0으로 돌아오는 로직
        curPatCount = 0;    //패턴이 바뀔때마다 실행 횟수 변수를 초기화함

        switch(patternIndex){
            case 0:
                CFireTarget();
                break;
            case 1:
                CFireAuto();
                break;
        }
    }
    void CFireTarget(){
        print("BFireTarget");
        BulletParticle TarC1 = GameObject.Find("CTar1").GetComponent<BulletParticle>();
        TarC1.FireTarget();
        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("CFireTarget",3.5f);
        else
            Invoke("CThink",2);
    }
    void CFireAuto(){
        print("BFireAuto");
        BulletParticle AutoFC1 = GameObject.Find("CTri1").GetComponent<BulletParticle>();
        BulletParticle AutoFC2 = GameObject.Find("CTri2").GetComponent<BulletParticle>();
        BulletParticle AutoFC3 = GameObject.Find("CTri3").GetComponent<BulletParticle>();
        BulletParticle AutoFC4 = GameObject.Find("CTri4").GetComponent<BulletParticle>();
        BulletParticle AutoFC5 = GameObject.Find("CTri5").GetComponent<BulletParticle>();
        AutoFC1.FireAuto();
        AutoFC2.FireAuto();
        AutoFC3.FireAuto();   
        AutoFC4.FireAuto(); 
        AutoFC5.FireAuto(); 

        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("CFireAuto",3.5f);
        else
            Invoke("CThink",2);
    }

    void DoF(){
        if(!gameObject.activeSelf)
            return;

        Invoke("FThink",2);
    }

    void FThink(){
        patternIndex = patternIndex == 1 ? 0 : patternIndex + 1; //현재 패턴이 패턴 갯수를 넘기면 0으로 돌아오는 로직
        curPatCount = 0;    //패턴이 바뀔때마다 실행 횟수 변수를 초기화함

        switch(patternIndex){
            case 0:
                FFireTarget();
                break;
            case 1:
                FFireAuto();
                break;
        }
    }

    void FFireTarget(){
        BulletParticle TarF1 = GameObject.Find("FTar1").GetComponent<BulletParticle>();
        TarF1.FireTarget();
        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("FFireTarget",3.5f);
        else
            Invoke("FThink",2);
    }

    void FFireAuto(){
        BulletParticle AutoF1 = GameObject.Find("FTri1").GetComponent<BulletParticle>();
        BulletParticle AutoF2 = GameObject.Find("FTri2").GetComponent<BulletParticle>();
        BulletParticle AutoF3 = GameObject.Find("FTri3").GetComponent<BulletParticle>();
        BulletParticle AutoF4 = GameObject.Find("FTri4").GetComponent<BulletParticle>();
        BulletParticle AutoF5 = GameObject.Find("FTri5").GetComponent<BulletParticle>();
        BulletParticle AutoF6 = GameObject.Find("FTri6").GetComponent<BulletParticle>();
        BulletParticle AutoF7 = GameObject.Find("FTri7").GetComponent<BulletParticle>();
        BulletParticle AutoF8 = GameObject.Find("FTri8").GetComponent<BulletParticle>();
        BulletParticle AutoF9 = GameObject.Find("FTri9").GetComponent<BulletParticle>();
        BulletParticle AutoF10 = GameObject.Find("FTri10").GetComponent<BulletParticle>();
        BulletParticle AutoF11 = GameObject.Find("FTri11").GetComponent<BulletParticle>();
        BulletParticle AutoF12 = GameObject.Find("FTri12").GetComponent<BulletParticle>();
        BulletParticle AutoF13 = GameObject.Find("FTri13").GetComponent<BulletParticle>();
        AutoF1.FireAuto();
        AutoF2.FireAuto();
        AutoF3.FireAuto();
        AutoF4.FireAuto();
        AutoF5.FireAuto();
        AutoF6.FireAuto();
        AutoF7.FireAuto();
        AutoF8.FireAuto();
        AutoF9.FireAuto();
        AutoF10.FireAuto();
        AutoF11.FireAuto();
        AutoF12.FireAuto();
        AutoF13.FireAuto();

        curPatCount++;

        if(curPatCount < maxPatCount[patternIndex])
            Invoke("FFireAuto",3.5f);
        else
            Invoke("FThink",2);
    }

    void BossReload(){
        curShotDelay += Time.deltaTime;
    }
}
