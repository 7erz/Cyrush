using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    WeaponManager weaponManager;
    AudioSource audioSource;
    [Header("Collider Material Settings")]
    public PhysicsMaterial2D physicsMaterial2D;
    
    [Header("MovingSprites")]
    public Sprite[] sprites; 
    // public GameManager gameManager;
    [Header("GameDebugProgress")]
    public static bool isDead = false;
    public static bool isShowResult = false;
    public GameObject expBar;
    public GameObject LvPanel;
    public static float speed = 1;
    public static float maxSpeed = 1;
    public int score;
    public static int coin = 0;
    public static float defaultDropRate = 25;
    public static float DropRateIncrease = 1;
    public float dropRateTotal;
    
    public float curExp;
    public float maxExp;
    public float jumpPower;
    public float jumpCountMax;
    public float jumpCount = 0;
    
    [Header("PlayerSound")]
    public AudioClip audioJump;
    public AudioClip audioRun;
    [Header("Joystick")]
    public FixedJoystick joy;
    bool touchOn;
    public Button buttonStatus;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start() {
        DebugPlayer();
    }
    void Update() {
        dropRateTotal = defaultDropRate * DropRateIncrease;
        spriteRenderer.color = new Color(55/255f,255/255f,255/255f,1);
        VerMove();
        PlayerDropRate();
        Leveling();
        Dying();
        DebugPlayer();
    }
    void FixedUpdate() {
        HorMove();
        RayCast();
    }

    void RayCast(){
        //레이캐스트
        Debug.DrawRay(rigid.position,Vector2.down,new Color(0,1,0));
        Debug.DrawRay(rigid.position,Vector2.right,new Color(1,0,0));
        if(rigid.linearVelocity.y < 0){
            //캐스트히트
            RaycastHit2D rayFloorHit = Physics2D.Raycast(rigid.position,Vector2.down, 1, LayerMask.GetMask("Platform"));
            if(rayFloorHit.collider != null){
                if(rayFloorHit.distance < 1.2f){
                    anim.SetBool("isJump",false);
                    anim.SetBool("isStillJump",false);
                    jumpCount = 0;
                    buttonStatus.GetComponent<Button>().interactable = true;
                }
            }
        }
        RaycastHit2D rayWallHit = Physics2D.Raycast(rigid.position,Vector2.right, 1, LayerMask.GetMask("InvisibleWall"));
        if(Input.GetKey(KeyCode.D) || joy.Horizontal == 1){
            if(rayWallHit.collider != null){
                if(rayWallHit.distance < 0.1f){
                    rigid.linearVelocity = new Vector2(0,rigid.linearVelocity.y);
                }   
            }
        }
    }

    void HorMove(){  
        //이동 속도 + 좌우 이동
        // float h = Input.GetAxisRaw("Horizontal");
        if(isDead == false){
            if(Input.GetKey(KeyCode.D) || joy.Horizontal >= 0.5){
                rigid.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }else if(Input.GetKey(KeyCode.A) || joy.Horizontal <= -0.5){
                rigid.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        }
        if(rigid.linearVelocity.x > maxSpeed) //오른쪽 맥스 스피드
            rigid.linearVelocity = new Vector2(maxSpeed,rigid.linearVelocity.y);
        if(rigid.linearVelocity.x < -maxSpeed) //왼족 맥스 스피드
            rigid.linearVelocity = new Vector2(-maxSpeed,rigid.linearVelocity.y);
    }
    void VerMove(){
        //점프 애니메이션 제어
        if(jumpCount < jumpCountMax){
            if(Input.GetButtonDown("Jump")){
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJump",true);
                jumpCount++;
                if(jumpCount >= 2){
                    buttonStatus.GetComponent<Button>().interactable = false;
                    anim.SetBool("isStillJump",true);
                }
            }
        }

        // //좌우이동 속도
        if(Input.GetButtonUp("Horizontal")){
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.normalized.x*0.5f,rigid.linearVelocity.y);
        }

    }

    public void VerMoveTouch(){
        if(jumpCount < jumpCountMax){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump",true);
            jumpCount++;
            if(jumpCount >= 2){
                buttonStatus.GetComponent<Button>().interactable = false;
                anim.SetBool("isStillJump",true);
            }
        }

        // //좌우이동 속도
        if(Input.GetButtonUp("Horizontal")){
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.normalized.x*0.5f,rigid.linearVelocity.y);
        }

    }
    public void PlayerDead(){
        PlayerMove.isDead = true;
    }
    void Dying(){
        if(isDead){
            GameManager.isOver = true;
            GetComponent<Collider2D>().sharedMaterial = physicsMaterial2D;
            anim.SetBool("isDead",true);
            if(jumpCount == 0){
                anim.SetBool("isDie",true);
                isShowResult = true;
            }
        }else{
            anim.SetBool("isDead",false);
            isShowResult = false;
        }
    }

    void Leveling(){
        expBar.transform.position = transform.position + new Vector3(0,1,0);
        if(curExp >= maxExp){
            curExp = curExp - maxExp;
            GameManager.PLv++;
            if(GameManager.curBoss == false){
                GameManager.isSpawn = false;
            }
            GameManager.isLvSet = true;
            LvPanel.SetActive(true);
            Time.timeScale = 0;
            maxExp *= 1.5f;
        }
    }
    
    public void Reset(){
        isDead = false;
        anim.SetBool("isDead",true);
        anim.SetBool("isDie",true);
        anim.SetBool("isJump",false);
        anim.SetBool("isStillJump",false);
        GameManager.PLv = 1;
        Bullet.bonusDmg = 1;
        maxSpeed = 1;
        Enemy.coinRate = 30;
        Enemy.coinValue = 1;
        coin = 0;
        GameManager.isOver = false;
        GameManager.curBoss = false;
        GameManager.isSpawn = false;
        MoveBossEffect.isDisBossEff = false;
    }

    void PlayerDropRate(){
        if(dropRateTotal > 70){
            dropRateTotal = 70;
        }
    }
    void DebugPlayer(){
         if(Input.GetKey(KeyCode.Alpha5)){
            Debug.Log("코인 드랍률 :" + (Enemy.coinRate - Enemy.item1Rate));
            Debug.Log("보너스 데미지 : " + Bullet.bonusDmg);
            Debug.Log("플레이어 이동속도 :" + maxSpeed);
            Debug.Log("코인 획득 량 : " + Enemy.coinValue);
            Debug.Log("총 드랍량 :" + dropRateTotal + "증가량 : " + DropRateIncrease);
         }
    }

    

    void PlaySound(string action){
        switch(action){
            case "JUMP":
                audioSource.clip = audioJump;
                break;
            case "RUN":
                audioSource.clip = audioRun;
                break;
        }
        audioSource.Play();
    }

}
