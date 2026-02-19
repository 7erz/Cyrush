using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Strings")]
    public string[] enemyObjs;
    public string[] bossObjs;
    public string[] decosObjs;
    public string[] randomDecosObjs;
    [Header("EnemySpawn Option1")]
    public Transform[] spawnPointGroup1;
    public float maxSpawnDelay1;
    public float curSpawnDelay1;
    [Header("EnemySpawn Option2")]
    // public Transform[] spawnPointGroup2;
    public float maxSpawnDelay2;
    public float curSpawnDelay2;
    [Header("EnemySpawn Option3")]
    // public Transform[] spawnPointGroup3;
    public float maxSpawnDelay3;
    public float curSpawnDelay3;
    [Header("EnemySpawn Option4")]
    // public Transform[] spawnPointGroup4;
    public float maxSpawnDelay4;
    public float curSpawnDelay4;
    [Header("EnemySpawn Option5")]
    // public Transform[] spawnPointGroup5;
    public float maxSpawnDelay5;
    public float curSpawnDelay5;
    [Header("EnemySpawn Option Sky1")]
    public Transform[] spawnPointGroupS1;
    public float maxSpawnDelayS1;
    public float curSpawnDelayS1;
    [Header("EnemySpawn Option Sky2")]
    // public Transform[] spawnPointGroupS2;
    public float maxSpawnDelayS2;
    public float curSpawnDelayS2;
    [Header("BossSpawn Option")]
    public Transform BossSpawnPoint;
    [Header("BossSpawn Option")]
    public static bool isSpawn = false;
    public static bool curBoss = false;
    public bool isFinalSpawn = false;
    [Header("RandomDecoration Option")]
    public static int ranDPoint; 
    public Transform[] spawnRandomDecoPoints;
    public float maxRandomDecoSpawnDelay;
    public float curRandomDecoSpawnDelay;
    [Header("SmallMountain Option")]
    public Transform spawnSMPoints;
    public float maxSMSpawnDelay;
    public float curSMSpawnDelay;
    [Header("Sign Option")]
    public Transform spawnSignPoint;
    public float maxSignSpawnDelay;
    public float curSignSpawnDelay;
    [Header("OverDeco Option")]
    public Transform spawnOverPoint;
    public float maxOverSpawnDelay;
    public float curOverSpawnDelay;
    [Header("PolePoint Option")]
    public Transform spawnPolePoint;
    public float maxPoleSpawnDelay;
    public float curPoleSpawnDelay;
    
    public ObjectManager objectManager;
    public GameObject player;
    Decos decos;
    DecosRandom decosRan;
    PlayerMove playerLv;

    [Header("Setting Import")]  //세팅 가져오기
    public int stageLv;
    public static int PLv = 1; 
    public static float bossMultipler = 1;
    public static float healthMultipler = 1;
    public static float xpMultipler = 1;
    public static float scoreMultipler = 1;
    public static float speedMultipler = 1;
    public static float maxShotDelayMultipler = 1;

   
    // private int totalMin = 0;
    public GameObject gameOverSet;  //게임오버(결과창 띄우기)
    public static bool isOver = false;
    public GameObject menuSet;      //일시정지 메뉴
    public static bool isMenu = false;
    public GameObject lvBonusSet;   //레벨업 메뉴
    public static bool isLvSet = false;
    public GameObject WarnSign;
    void Awake(){
        enemyObjs = new string[]{"EnemyC","EnemyS","EnemyT"};
        bossObjs = new string[]{"BossA","BossB","BossC"};
        randomDecosObjs = new string[]{"Cactus1","Cactus2","Drum1","Drum2",
                                        "Tree1"};
        decosObjs = new string[]{"SmallMountain","Sign1",
                                "OverCactus", "OverTree","Telepole"};
    }
    void Start(){
        decos = GetComponent<Decos>();
        decosRan = GetComponent<DecosRandom>();
        playerLv = player.GetComponent<PlayerMove>();
    }
    
    void Update(){
        //적 스폰 로직
        EnemySpawnLogicWithLv();
        StageLeveling();
        //장식 스폰 로직
        RandomDecoSpawnLogic();
        SMSpawnLogic();
        SignSpawnLogic();
        OverSpawnLogic();
        PoleSpawnLogic();
        MultiplerManage();
        //일시정지,사망 로직
        GameOverLogic();
    }
    void FixedUpdate() {
        
    }
    //적 스폰 로직
    void SpawnEnemy(){
        int ranEnemy = Random.Range(0,stageLv);//위 [] 순으로 랜덤
        int ranPoint = Random.Range(0,6);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPointGroup1[ranPoint].position;
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.objectManager = objectManager;
    }
    void SpawnSkyEnemy(){
        int ranEnemy = Random.Range(0,stageLv - 1);//위 [] 순으로 랜덤
        int ranPoint = Random.Range(0,3);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPointGroupS1[ranPoint].position;
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.objectManager = objectManager;
    }
    // 적 스폰 딜레이 로직
    void EnemySpawnLogic1(){
        if(PlayerMove.isDead == false)
            curSpawnDelay1 += Time.deltaTime;
        else
            curSpawnDelay1 = maxSpawnDelay1;

        if(curSpawnDelay1 > maxSpawnDelay1){
            SpawnEnemy();
            curSpawnDelay1 = 0;
            maxSpawnDelay1 = Random.Range(0.5f,1.5f);
        }
    }
    void EnemySpawnLogic2(){
        if(PlayerMove.isDead == false)
            curSpawnDelay2 += Time.deltaTime;
        else
            curSpawnDelay2 = maxSpawnDelay2;

        if(curSpawnDelay2 > maxSpawnDelay2){
            SpawnEnemy();
            curSpawnDelay2 = 0;
            maxSpawnDelay2 = Random.Range(0.5f,1.2f);
        }
    }
    void EnemySpawnLogic3(){
        if(PlayerMove.isDead == false)
            curSpawnDelay3 += Time.deltaTime;
        else
            curSpawnDelay3 = maxSpawnDelay3;

        if(curSpawnDelay3 > maxSpawnDelay3){
            SpawnEnemy();
            curSpawnDelay3 = 0;
            maxSpawnDelay3 = Random.Range(0.4f,1.0f);
        }
    }
    void EnemySpawnLogic4(){
        if(PlayerMove.isDead == false)
            curSpawnDelay4 += Time.deltaTime;
        else
            curSpawnDelay4 = maxSpawnDelay4;

        if(curSpawnDelay4 > maxSpawnDelay4){
            SpawnEnemy();
            curSpawnDelay4 = 0;
            maxSpawnDelay4 = Random.Range(0.3f,1.0f);
        }
    }
    // void EnemySpawnLogic5(){
    //     if(PlayerMove.isDead == false)
    //         curSpawnDelay5 += Time.deltaTime;
    //     else
    //         curSpawnDelay5 = maxSpawnDelay5;

    //     if(curSpawnDelay5 > maxSpawnDelay5){
    //         SpawnEnemy();
    //         curSpawnDelay5 = 0;
    //         maxSpawnDelay5 = Random.Range(0.2f,0.8f);
    //     }
    // } 렉이 너무 걸림
    void EnemySpawnLogicS1(){
        if(PlayerMove.isDead == false)
            curSpawnDelayS1 += Time.deltaTime;
        else
            curSpawnDelayS1 = maxSpawnDelayS1;

        if(curSpawnDelayS1 > maxSpawnDelayS1){
            SpawnSkyEnemy();
            curSpawnDelayS1 = 0;
            maxSpawnDelayS1 = Random.Range(1.0f,3.0f);
        }
    }
    void EnemySpawnLogicS2(){
        if(PlayerMove.isDead == false)
            curSpawnDelayS2 += Time.deltaTime;
        else
            curSpawnDelayS2 = maxSpawnDelayS2;

        if(curSpawnDelayS2 > maxSpawnDelayS2){
            SpawnSkyEnemy();
            curSpawnDelayS2 = 0;
            maxSpawnDelayS2 = Random.Range(1.0f,2.0f);
        }
    }

    public void SpawnBoss(){
        int ranEnemy = Random.Range(0,3);
        int ranPoint = Random.Range(0,6);
        GameObject boss = objectManager.MakeObj(bossObjs[ranEnemy]);
        boss.transform.position = spawnPointGroup1[ranPoint].position;
        Rigidbody2D rigid = boss.GetComponent<Rigidbody2D>();
        Boss bossLogic = boss.GetComponent<Boss>();
        bossLogic.player = player;
        bossLogic.objectManager = objectManager;
        isSpawn = true;
    }

    void BossSpawnLogic(){
        if(curBoss == true){
            isSpawn = true;
        }
        if(curBoss == false && isSpawn == false){
            SpawnBoss();
            curBoss = true;
            isSpawn = true;
        }
    }

    public void SpawnFinalBoss(){
        GameObject boss = objectManager.MakeObj("FinalBoss");
        boss.transform.position = BossSpawnPoint.position;
        Rigidbody2D rigid = boss.GetComponent<Rigidbody2D>();
        Boss bossLogic = boss.GetComponent<Boss>();
        bossLogic.player = player;
        bossLogic.objectManager = objectManager;
    }

    void FinalBossSpawnLogic(){
        if(MoveBossEffect.isDisBossEff == true && isFinalSpawn == false){
            SpawnFinalBoss();
            isFinalSpawn = true;
        }
    }


    void EnemySpawnLogicWithLv(){   //적 스폰 제어 난이도 조절
        if(MoveBossEffect.isDisBossEff == false){
            EnemySpawnLogic1();
            if(PLv != 5){
                if(PLv >= 2){
                    EnemySpawnLogic2();
                    if(PLv >= 3){
                        EnemySpawnLogic3();
                        EnemySpawnLogicS1();
                        if(PLv >= 4){
                            EnemySpawnLogic4();
                            if(PLv >= 6){
                                EnemySpawnLogicS2();
                            }
                        }
                    }
                }
            }
            if(PLv % 5 == 0){
                BossSpawnLogic();
            }
        }else{
            FinalBossSpawnLogic();
        }
    }

    void StageLeveling(){       //적 유형 제어 난이도 조절
        if(PLv >= 2 && PLv <= 3){
            stageLv = 2;
        }else if(PLv >= 6){
            stageLv = 3;
        }
    }

    //랜덤 데코레이션 스폰 설정
    void SpawnRandomDeco(){
        int ranDecos = Random.Range(0,5);   //장식 배열
        ranDPoint = Random.Range(0,4);
        GameObject randecos = objectManager.MakeObj(randomDecosObjs[ranDecos]); //프리펩생성
        randecos.transform.position = spawnRandomDecoPoints[ranDPoint].position;    //생성 위치
        Rigidbody2D rigid = randecos.GetComponent<Rigidbody2D>();
        DecosRandom randecosLogic = randecos.GetComponent<DecosRandom>();
        randecosLogic.player = player;
        randecosLogic.objectManager = objectManager;   
    }
    void RandomDecoSpawnLogic(){
        if(PlayerMove.isDead == false)
            curRandomDecoSpawnDelay += Time.deltaTime;
        else
            curRandomDecoSpawnDelay = maxRandomDecoSpawnDelay;

        if(curRandomDecoSpawnDelay > maxRandomDecoSpawnDelay){
            SpawnRandomDeco();
            curRandomDecoSpawnDelay = 0;
            maxRandomDecoSpawnDelay = Random.Range(1.0f,2.0f);
        }
    }
    //여기서 211줄까지 고정형 데코레이션 스폰 설정
    void SpawnSM(){
        GameObject SMdeco = objectManager.MakeObj(decosObjs[0]);
        SMdeco.transform.position = spawnSMPoints.position;
        Rigidbody2D rigid = SMdeco.GetComponent<Rigidbody2D>();
        Decos SMdecoLogic = SMdeco.GetComponent<Decos>();
        SMdecoLogic.player = player;
        SMdecoLogic.objectManager = objectManager;
    }
    void SMSpawnLogic(){
        if(PlayerMove.isDead == false)
            curSMSpawnDelay += Time.deltaTime;
        else
            curSMSpawnDelay = maxSMSpawnDelay;

        if(curSMSpawnDelay > maxSMSpawnDelay){
            SpawnSM();
            curSMSpawnDelay = 0;
            maxSMSpawnDelay = Random.Range(10.0f,25.0f);
        }
    }
    
    void SpawnSign(){
        GameObject signDeco = objectManager.MakeObj(decosObjs[1]);
        signDeco.transform.position = spawnSignPoint.position;
        Rigidbody2D rigid = signDeco.GetComponent<Rigidbody2D>();
        Decos signDecoLogic = signDeco.GetComponent<Decos>();
        signDecoLogic.player = player;
        signDecoLogic.objectManager = objectManager;
        
    }
    void SignSpawnLogic(){
        if(PlayerMove.isDead == false)
            curSignSpawnDelay += Time.deltaTime;
        else
            curSignSpawnDelay = maxSignSpawnDelay;

        if(curSignSpawnDelay > maxSignSpawnDelay){
            SpawnSign();
            curSignSpawnDelay = 0;
            maxSignSpawnDelay = Random.Range(2.5f,5.0f);
        }
    }
    void SpawnOver(){
        int ranOver = Random.Range(2,4);
        GameObject overDeco = objectManager.MakeObj(decosObjs[ranOver]);
        overDeco.transform.position = spawnOverPoint.position;
        Rigidbody2D rigid = overDeco.GetComponent<Rigidbody2D>();
        Decos overDecoLogic = overDeco.GetComponent<Decos>();
        overDecoLogic.player = player;
        overDecoLogic.objectManager = objectManager;
    }
    void OverSpawnLogic(){
        if(PlayerMove.isDead == false)
            curOverSpawnDelay += Time.deltaTime;
        else
            curOverSpawnDelay = maxOverSpawnDelay;

        if(curOverSpawnDelay > maxOverSpawnDelay){
            SpawnOver();
            curOverSpawnDelay = 0;
            maxOverSpawnDelay = Random.Range(2.5f,4.0f);
        }
    }

    void SpawnPole(){
        GameObject poleDeco = objectManager.MakeObj(decosObjs[4]);
        poleDeco.transform.position = spawnPolePoint.position - new Vector3(0,0,1);
        Rigidbody2D rigid = poleDeco.GetComponent<Rigidbody2D>();
        Decos poleDecoLogic = poleDeco.GetComponent<Decos>();
        poleDecoLogic.player = player;
        poleDecoLogic.objectManager = objectManager;
    }
    void PoleSpawnLogic(){
        if(PlayerMove.isDead == false)
            curPoleSpawnDelay += Time.deltaTime;
        else
            curPoleSpawnDelay = maxPoleSpawnDelay;

        if(curPoleSpawnDelay > maxPoleSpawnDelay){
            SpawnPole();
            curPoleSpawnDelay = 0;
        }
    }

    public void MultiplerManage(){
        bossMultipler = (PLv / 5) + 1;

        if(PLv >= 11){
            healthMultipler = (PLv+1) / 2;
            xpMultipler = (PLv+1) / 5;
            scoreMultipler = (int)0.5;
        }
        if(PLv >= 16){
            speedMultipler = 1.5f;
            maxShotDelayMultipler = 0.5f;
        }
    }

    //일시정지 로직
    public void PauseLogic(){
        if(menuSet.activeSelf == false){
            menuSet.SetActive(true);
            isMenu = true;
        }else{
            menuSet.SetActive(false);
            isMenu = false;
        }
    }

    public void ResetTimeScale(){
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    void GameOverLogic(){
        if(PlayerMove.isShowResult){
            Invoke("GameOverEXE",1.0f);
        }
    }

    void GameOverEXE(){
        gameOverSet.SetActive(true);
    }
}
