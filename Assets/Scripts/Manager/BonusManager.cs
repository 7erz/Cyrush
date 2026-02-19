using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [Header("ItemList")]
    Dictionary<int, string> nameData;
    Dictionary<int, string> infoData;
    Dictionary<int, Sprite> picData;
    public Sprite[] picDataArr;
    void Awake(){
        nameData = new Dictionary<int, string>();
        infoData = new Dictionary<int, string>();
        picData = new Dictionary<int, Sprite>();
        GenerateData();
    }
    void GenerateData(){
        nameData.Add(0, "코인캐쳐");
        nameData.Add(1, "사격술 향상");
        nameData.Add(2, "체술");
        nameData.Add(3, "비트코인");
        nameData.Add(4, "드롭스");

        infoData.Add(0, "코인 획득 확률을 높입니다.(드랍률과 별개)");
        infoData.Add(1, "총기 데미지가 증가합니다.");
        infoData.Add(2, "이동 속도가 증가합니다.");
        infoData.Add(3, "코인 획득량이 +1 증가합니다.");
        infoData.Add(4, "아이템 드랍률을 높입니다.(코인 획득 확률과 별개");


        picData.Add(0,picDataArr[0]);
        picData.Add(1,picDataArr[1]);
        picData.Add(2,picDataArr[2]);
        picData.Add(3,picDataArr[3]);
        picData.Add(4,picDataArr[4]);

    }
    public string GetNameData(int id){
        return nameData[id];
    }
    public string GetInfoData(int id){
        return infoData[id];
    }
    public Sprite GetPicData(int id){
        return picData[id];
    }
}
