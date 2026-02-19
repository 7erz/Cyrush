using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemInfoManager : MonoBehaviour
{
    [Header("ItemList")]
    Dictionary<int, string> nameData;
    Dictionary<int, string> infoData;
    Dictionary<int, Sprite> picData;
    Dictionary<int, int> priceData;
    public Sprite[] picDataArr;

    void Awake() {
        nameData = new Dictionary<int, string>();
        infoData = new Dictionary<int, string>();
        picData = new Dictionary<int, Sprite>();
        priceData = new Dictionary<int, int>();
        GenerateData();
    }

    public void Update() {

    }

    void GenerateData(){
        nameData.Add(0, "피스톨");
        nameData.Add(1, "AK-47");
        nameData.Add(2,"아비오");


        nameData.Add(9998,"구매");
        nameData.Add(9999,"장착");


        infoData.Add(0, "기본 지급되는 권총중 하나입니다. 연사력과 데미지 모두 느립니다. 하지만 권총 한자루면 어떠한 역경도 어쩌구 저쩌구...");
        infoData.Add(1, "무난한 연사력으로 적들을 제압할수 있습니다. 권총과 데미지는 같지만 연사력에서 뛰어납니다.");
        infoData.Add(2, "에너지탄을 사용하는 미래형 권총입니다. 데미지와 연사력 모두 뛰어납니다!");

        
        infoData.Add(9998,null);
        infoData.Add(9999,null);
    

        picData.Add(0,picDataArr[0]);
        picData.Add(1,picDataArr[1]);
        picData.Add(2,picDataArr[2]);

        priceData.Add(0,0);
        priceData.Add(1,100);
        priceData.Add(2,350);
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

    public int GetPriceData(int id){
        return priceData[id];
    }
}
