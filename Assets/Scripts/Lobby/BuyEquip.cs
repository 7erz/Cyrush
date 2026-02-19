using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyEquip : MonoBehaviour
{
    public int bebtnID;
    public TextMeshProUGUI ButtonName;
    public ItemInfoManager iIM;
    void Start()
    {
        ButtonName.GetComponent<TextMeshProUGUI>().text = iIM.GetNameData(bebtnID);
    }
    public void equipCheck(){
        
    }
    public void ChangeWeapon(){
        WeaponManager.WeaponNum = ButtonInfoID.setId;
        Debug.Log(WeaponManager.WeaponNum + "으로 교체됨");
    }
}
