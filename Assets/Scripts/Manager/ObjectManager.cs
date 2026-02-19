using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    WeaponAngle weaponAngle;

    //프리펩 배열
    //public 사용 안함
    public GameObject RocketPrefab;     //로켓탄
    public GameObject HBulletPrefab;    //소총탄
    public GameObject EBulletPrefab;    //에너지탄
    public GameObject PBulletPrefab;    //권총탄
    //적
    public GameObject EnemyCPrefab;     //원 적
    public GameObject EnemySPrefab;     //사각 적
    public GameObject EnemyTPrefab;     //삼각 적
    public GameObject ECBulletPrefab;   //원 적 총탄
    public GameObject ETBulletPrefab;   //삼각 적 총탄
    //아이템
    public GameObject CoinPrefab;       //코인
    public GameObject CoinTrailPrefab;  //코인 자동 변환 이펙트
    public GameObject BombPrefab;       //폭탄 
    //장식
    public GameObject Cactus01Prefab;   //cactus01(선인장01)
    public GameObject Cactus02Prefab;   //cactus02(선인장02)
    public GameObject Drum01Prefab;     //drum01(드럼통01)
    public GameObject Drum02Prefab;     //drum02(드럼통02)
    public GameObject Sign01Prefab;     //sign01(표지판01)
    public GameObject TelepolePrefab;   //telepole(전신주)
    public GameObject Tree01Prefab;     //tree01(나무01)
    public GameObject smallMountainPrefab;      //Small_Mountain(작은 산)
    //화면가리개
    public GameObject overCactus01Prefab;   //화면가리기용 선인장
    public GameObject overTreePrefab;       //화면가리기용 나무
    //보스
    public GameObject BossAPrefab;
    public GameObject BossBPrefab;
    public GameObject BossCPrefab;
    public GameObject FinalBossPrefab;

    // 총알
    GameObject[] Rocket;
    GameObject[] HBullet;
    GameObject[] EBullet;
    GameObject[] PBullet;
    //적
    GameObject[] EnemyC;
    GameObject[] EnemyS;
    GameObject[] EnemyT;
    GameObject[] ECBullet;
    GameObject[] ETBullet;
    //아이템
    GameObject[] Coin;
    GameObject[] CoinTrail;
    GameObject[] Bomb;
    //장식
    GameObject[] Cactus01;
    GameObject[] Cactus02;
    GameObject[] Drum01;
    GameObject[] Drum02;
    GameObject[] Sign01;
    GameObject[] Telepole;
    GameObject[] Tree01;
    GameObject[] smallMountain;
    //화면가리개
    GameObject[] overCactus1;
    GameObject[] overTree;
    //보스
    GameObject[] BossA;
    GameObject[] BossB;
    GameObject[] BossC;
    GameObject[] FinalBoss;


    //받아오기
    GameObject[] targetPool;
    // GameObject[] bsTargetPool;

    void Awake(){
        //한번에 등장 가능한 갯수를 배열로 길이 할당
        Rocket = new GameObject[100];
        HBullet = new GameObject[100];
        EBullet = new GameObject[100];
        PBullet = new GameObject[100];
        
        EnemyC = new GameObject[100];
        EnemyS = new GameObject[100];
        EnemyT = new GameObject[100];
        ECBullet = new GameObject[600];
        ETBullet = new GameObject[100];

        Coin = new GameObject[100];
        CoinTrail = new GameObject[100];
        Bomb = new GameObject[20];

        Cactus01 = new GameObject[20];
        Cactus02 = new GameObject[20];
        Drum01 = new GameObject[20];
        Drum02 = new GameObject[20];
        Sign01 = new GameObject[20];
        Telepole = new GameObject[30];
        Tree01 = new GameObject[20];
        smallMountain = new GameObject[10];

        overCactus1 = new GameObject[5];
        overTree = new GameObject[5];

        BossA = new GameObject[2];
        BossB = new GameObject[2];
        BossC = new GameObject[2];
        FinalBoss = new GameObject[2];

        
        Generate();
    }

    void Generate(){
        //총알
        // for(int index = 0; index < Bs.Length; index++){
        //     Bs[index] = Instantiate(BsPrefab);
        //     Bs[index].SetActive(false);
        // }
        for(int index = 0; index < Rocket.Length; index++){
            Rocket[index] = Instantiate(RocketPrefab);
            Rocket[index].SetActive(false);
        }
        for(int index = 0; index < HBullet.Length; index++){
            HBullet[index] = Instantiate(HBulletPrefab);
            HBullet[index].SetActive(false);
        }
        for(int index = 0; index < EBullet.Length; index++){
            EBullet[index] = Instantiate(EBulletPrefab);
            EBullet[index].SetActive(false);
        }
        for(int index = 0; index < PBullet.Length; index++){
            PBullet[index] = Instantiate(PBulletPrefab);
            PBullet[index].SetActive(false);
        }
        //적
        for(int index = 0; index < EnemyC.Length; index++){
            EnemyC[index] = Instantiate(EnemyCPrefab);
            EnemyC[index].SetActive(false);
        }
        for(int index = 0; index < EnemyS.Length; index++){
            EnemyS[index] = Instantiate(EnemySPrefab);
            EnemyS[index].SetActive(false);
        }
        for(int index = 0; index < EnemyT.Length; index++){
            EnemyT[index] = Instantiate(EnemyTPrefab);
            EnemyT[index].SetActive(false);
        }
        for(int index = 0; index < ECBullet.Length; index++){
            ECBullet[index] = Instantiate(ECBulletPrefab);
            ECBullet[index].SetActive(false);
        }
        for(int index = 0; index < ETBullet.Length; index++){
            ETBullet[index] = Instantiate(ETBulletPrefab);
            ETBullet[index].SetActive(false);
        }
        for(int index = 0; index < Coin.Length; index++){
            Coin[index] = Instantiate(CoinPrefab);
            Coin[index].SetActive(false);
        }
        for(int index = 0; index < CoinTrail.Length; index++){
            CoinTrail[index] = Instantiate(CoinTrailPrefab);
            CoinTrail[index].SetActive(false);
        }
        for(int index = 0; index < Bomb.Length; index++){
            Bomb[index] = Instantiate(BombPrefab);
            Bomb[index].SetActive(false);
        }
        for(int index = 0; index < Cactus01.Length; index++){
            Cactus01[index] = Instantiate(Cactus01Prefab);
            Cactus01[index].SetActive(false);
        }
        for(int index = 0; index < Cactus02.Length; index++){
            Cactus02[index] = Instantiate(Cactus02Prefab);
            Cactus02[index].SetActive(false);
        }
        for(int index = 0; index < Drum01.Length; index++){
            Drum01[index] = Instantiate(Drum01Prefab);
            Drum01[index].SetActive(false);
        }
        for(int index = 0; index < Drum02.Length; index++){
            Drum02[index] = Instantiate(Drum02Prefab);
            Drum02[index].SetActive(false);
        }
        for(int index = 0; index < Sign01.Length; index++){
            Sign01[index] = Instantiate(Sign01Prefab);
            Sign01[index].SetActive(false);
        }
        for(int index = 0; index < Telepole.Length; index++){
            Telepole[index] = Instantiate(TelepolePrefab);
            Telepole[index].SetActive(false);
        }
        for(int index = 0; index < Tree01.Length; index++){
            Tree01[index] = Instantiate(Tree01Prefab);
            Tree01[index].SetActive(false);
        }
        for(int index = 0; index < smallMountain.Length; index++){
            smallMountain[index] = Instantiate(smallMountainPrefab);
            smallMountain[index].SetActive(false);
        }
        for(int index = 0; index < overCactus1.Length; index++){
            overCactus1[index] = Instantiate(overCactus01Prefab);
            overCactus1[index].SetActive(false);
        }
        for(int index = 0; index < overTree.Length; index++){
            overTree[index] = Instantiate(overTreePrefab);
            overTree[index].SetActive(false);
        }
        for(int index = 0; index < BossA.Length; index++){
            BossA[index] = Instantiate(BossAPrefab);
            BossA[index].SetActive(false);
        }
        for(int index = 0; index < BossB.Length; index++){
            BossB[index] = Instantiate(BossBPrefab);
            BossB[index].SetActive(false);
        }
        for(int index = 0; index < BossC.Length; index++){
            BossC[index] = Instantiate(BossCPrefab);
            BossC[index].SetActive(false);
        }
        for(int index = 0; index < FinalBoss.Length; index++){
            FinalBoss[index] = Instantiate(FinalBossPrefab);
            FinalBoss[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {  
        switch(type)
        {
            //총알
            case "HBullet":
                targetPool = HBullet;
                break;
            case "Rocket":
                targetPool = Rocket;
                break;
            case "EBullet":
                targetPool = EBullet;
                break;
            case "PBullet":
                targetPool = PBullet;
                break;
            //적
            case "EnemyC":
                targetPool = EnemyC;
                break;
            case "EnemyS":
                targetPool = EnemyS;
                break;
            case "EnemyT":
                targetPool = EnemyT;
                break;
            case "EnemyBulletC":
                targetPool = ECBullet;
                break;
            case "EnemyBulletT":
                targetPool = ETBullet;
                break;
            //아이템
            case "Coin":
                targetPool = Coin;
                break;
            case "CoinTrail":
                targetPool = CoinTrail;
                break;
            case "Bomb":
                targetPool = Bomb;
                break;
            //장식
            case "Cactus1":
                targetPool = Cactus01;
                break;
            case "Cactus2":
                targetPool = Cactus02;
                break;
            case "Drum1":
                targetPool = Drum01;
                break;
            case "Drum2":
                targetPool = Drum02;
                break;
            case "Sign1":
                targetPool = Sign01;
                break;
            case "Telepole":
                targetPool = Telepole;
                break;
            case "Tree1":
                targetPool = Tree01;
                break;
            case "SmallMountain":
                targetPool = smallMountain;
                break;
            //가리개용 장식
            case "OverCactus":
                targetPool = overCactus1;
                break;
            case "OverTree":
                targetPool = overTree;
                break;
            //보스
            case "BossA":
                targetPool = BossA;
                break;
            case "BossB":
                targetPool = BossB;
                break;
            case "BossC":
                targetPool = BossC;
                break;
            case "FinalBoss":
                targetPool = FinalBoss;
                break;
        }

        for(int index = 0;index < targetPool.Length;index++){
            if(!targetPool[index].activeSelf){  //비활성 오브젝트 접근해 활성 후, 값 반환
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }
    public GameObject[] GetPool(string type)
    {
        switch(type)
        {
            //총알
            case "HBullet":
                targetPool = HBullet;
                break;
            case "Rocket":
                targetPool = Rocket;
                break;
            case "EBullet":
                targetPool = EBullet;
                break;
            case "PBullet":
                targetPool = PBullet;
                break;
            //적
            case "EnemyC":
                targetPool = EnemyC;
                break;
            case "EnemyS":
                targetPool = EnemyS;
                break;
            case "EnemyT":
                targetPool = EnemyT;
                break;
            case "EnemyBulletC":
                targetPool = ECBullet;
                break;
            case "EnemyBulletT":
                targetPool = ETBullet;
                break;
            //아이템
            case "Coin":
                targetPool = Coin;
                break;
            case "CoinTrail":
                targetPool = CoinTrail;
                break;
            case "Bomb":
                targetPool = Bomb;
                break;
            //장식
            case "Cactus1":
                targetPool = Cactus01;
                break;
            case "Cactus2":
                targetPool = Cactus02;
                break;
            case "Drum1":
                targetPool = Drum01;
                break;
            case "Drum2":
                targetPool = Drum02;
                break;
            case "Sign1":
                targetPool = Sign01;
                break;
            case "Telepole":
                targetPool = Telepole;
                break;
            case "Tree1":
                targetPool = Tree01;
                break;
            case "SmallMountain":
                targetPool = smallMountain;
                break;
            //가리개용 장식
            case "OverCactus":
                targetPool = overCactus1;
                break;
            case "OverTree":
                targetPool = overTree;
                break;
            //보스
            case "BossA":
                targetPool = BossA;
                break;
            case "BossB":
                targetPool = BossB;
                break;
            case "BossC":
                targetPool = BossC;
                break;
            case "FinalBoss":
                targetPool = FinalBoss;
                break;
        }
        return targetPool;              //딜레이 0초 초기화
    }

}
