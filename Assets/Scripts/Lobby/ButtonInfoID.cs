using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfoID : MonoBehaviour
{
    public int getID;
    public int bebtnID;
    public static int setId;
    public Transform[] buttonT; //정리대상
    public Button buttonStatus;

    public TextMeshProUGUI InfoName;
    public TextMeshProUGUI InfoInfo;
    public Image InfoImg;
    public TextMeshProUGUI InfoPrice;
    public TextMeshProUGUI ButtonName;
    public ItemInfoManager iIM;
    ButtonId buttonId;
    

    void Start() {
        buttonId = GetComponent<ButtonId>();
        //getID = buttonT[setId].gameObject.GetComponent<ButtonId>().btnID;
    }

    void Update() {
        InfoName.GetComponent<TextMeshProUGUI>().text = iIM.GetNameData(setId);
        InfoInfo.GetComponent<TextMeshProUGUI>().text = iIM.GetInfoData(setId);
        InfoImg.GetComponent<Image>().sprite = iIM.GetPicData(setId);
        InfoImg.GetComponent<Image>().SetNativeSize();
        InfoPrice.GetComponent<TextMeshProUGUI>().text = "가격 : " + iIM.GetPriceData(setId).ToString();
        canBuyCheck(); 
        BuyCheck();
    }
    public void canBuyCheck(){
        if(buttonT[setId].gameObject.GetComponent<ButtonId>().isBuy == false){
            if(CoinShow.haveCoin < iIM.GetPriceData(setId)){
                buttonStatus.GetComponent<Button>().interactable = false;
                InfoPrice.GetComponent<TextMeshProUGUI>().color = Color.red;
                ButtonName.GetComponent<TextMeshProUGUI>().text = iIM.GetNameData(bebtnID);
            }else{
                buttonStatus.GetComponent<Button>().interactable = true;
                InfoPrice.GetComponent<TextMeshProUGUI>().color = new Color(55/255f,255/255f,255/255f,1);
                ButtonName.GetComponent<TextMeshProUGUI>().text = iIM.GetNameData(bebtnID);
            }
        }else if(buttonT[setId].gameObject.GetComponent<ButtonId>().isBuy == true){
            buttonStatus.GetComponent<Button>().interactable = true;   
        }
    }

    public void Buy(){
        if(buttonT[setId].gameObject.GetComponent<ButtonId>().isBuy == false){
            CoinShow.haveCoin -= iIM.GetPriceData(setId);
            buttonT[setId].gameObject.GetComponent<ButtonId>().isBuy = true;
            ES3AutoSaveMgr.Current.Save();
        }

    }
    void BuyCheck(){
        if(buttonT[setId].gameObject.GetComponent<ButtonId>().isBuy == true){
            ButtonName.GetComponent<TextMeshProUGUI>().text = iIM.GetNameData(bebtnID + 1);
        }
    }
    public void ChangeWeapon(){
        if(buttonT[setId].gameObject.GetComponent<ButtonId>().isBuy == true){
            WeaponManager.WeaponNum = ButtonInfoID.setId;
            Debug.Log(WeaponManager.WeaponNum + "으로 교체됨");
            ES3AutoSaveMgr.Current.Save();
        }
    }
    public void Test(){
        Debug.Log(buttonT[setId].gameObject.GetComponent<ButtonId>().btnID + "눌러진 버튼의 숫자");
        // Debug.Log(setId + "SID");
        // Debug.Log(getID + "GID");
    }


}
