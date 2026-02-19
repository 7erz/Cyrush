// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;    //Input Output


// // //저장디이터 제이슨으로 변환후 외부에 저장
// // //데이터 형태로 변환후 데이터를 사용

// // public class PlayerData{
// //     public int equiped;
// //     public PlayerData(int equiped){
// //         this.equiped = equiped;
// //     }
// // }

// // public class ShopData{
// //     public int buttonid;
// //     public bool purchased;

// //     public ShopData(int buttonid, bool purchased){
// //         this.buttonid = buttonid;
// //         this.purchased = purchased;
// //     }

// // }
// // public class DataManager : MonoBehaviour
// // {
// //     public Transform[] buttonT;
// //     PlayerData nowPlayer = new PlayerData(WeaponManager.WeaponNum);
// //     ShopData curShop = new ShopData(buttonT[setId].gameObject.GetComponent<ButtonId>().isBuy);
// //     string path;
// //     string fileName = "save";

// //     void Awake()
// //     {
// //         DontDestroyOnLoad(this.gameObject);

// //         path = Application.persistentDataPath + "/" ;  //유니티에서 폴더를 생성해 주는 곳에 저장
// //     }

// //     void Start(){

// //     }
// //     void Update()
// //     {
        
// //     }

// //     public void PlayerSave(){
// //         string jdata_0 = 
// //     }

// //     public void SaveData(){
// //         string data = JsonUtility.ToJson(nowPlayer);  //string값으로 받음

// //         File.WriteAllText(path + fileName,data);
// //     }

// //     public void LoadData(){
// //         string data = File.ReadAllText(path + fileName);

// //         JsonUtility.FromJson<PlayerData>(data);
// //     }
// // }

//     void AThink(){
//         patternIndex = patternIndex == 2 ? 0 : patternIndex + 1; //현재 패턴이 패턴 갯수를 넘기면 0으로 돌아오는 로직
//         curPatCount = 0;    //패턴이 바뀔때마다 실행 횟수 변수를 초기화함

//         switch(patternIndex){
//             case 0:
//                 AFireAuto();
//                 break;
//             case 1:
//                 AFireTarget();
//                 break;
//             case 2:
//                 AFireStr();
//                 break;
//         }
//     }

//     void AFireAuto(){
//         autoF.Play();

//         curPatCount++;

//         if(curPatCount < maxPatCount[patternIndex])
//             Invoke("AFireAuto",3.5f);
//         else
//             Invoke("AThink",2);
//     }

//     void AFireTarget(){
//         tarF.Play();

//         curPatCount++;

//         if(curPatCount < maxPatCount[patternIndex])
//             Invoke("AFireTarget",3.5f);
//         else
//             Invoke("AThink",2);
//     }

//     void AFireStr(){
//         strF.Play();

//         curPatCount++;

//         if(curPatCount < maxPatCount[patternIndex])
//             Invoke("AFireStr",3.5f);
//         else
//             Invoke("AThink",2);
//     }

//     void BossReload(){
//         curShotDelay += Time.deltaTime;
//     }
