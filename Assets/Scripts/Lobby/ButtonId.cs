using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonId : MonoBehaviour
{
    public bool isBuy;
    public int btnID;
    public TextMeshProUGUI ButtonName;
    public Image ButtonImg;
    public ItemInfoManager iIM;

    void Start()
    {
        ButtonName.GetComponent<TextMeshProUGUI>().text = iIM.GetNameData(btnID);
        ButtonImg.GetComponent<Image>().sprite = iIM.GetPicData(btnID);
    }
    public void ChangeNum(){
        ButtonInfoID.setId = btnID;
        Debug.Log(ButtonInfoID.setId + "으로 변경됨");
    }
    public void BuySave(){
        ES3AutoSaveMgr.Current.Save();
    }


}
