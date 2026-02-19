using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LvButtonId : MonoBehaviour
{
    public Transform[] buttonL;
    public int lvBtnId;         //버튼의 넘버
    public int bonusRnd;        //매니저에서 받아올 수
    public TextMeshProUGUI BonusName;
    public TextMeshProUGUI BonusInfo;
    public Image BonusImg;
    public BonusManager bonusManager;
    void OnEnable()//버튼 클릭이벤트로 클릭시 다음 활성화때 아이템 랜덤 돌리기
    {
        bonusRnd = Random.Range(0,5);
    }
    void Update(){
        ButtonStatus();
        RandomChoose();
        
    }

    void ButtonStatus(){    //버튼에 데이터 할당
        BonusName.GetComponent<TextMeshProUGUI>().text = bonusManager.GetNameData(bonusRnd);
        BonusInfo.GetComponent<TextMeshProUGUI>().text = bonusManager.GetInfoData(bonusRnd);
        BonusImg.GetComponent<Image>().sprite = bonusManager.GetPicData(bonusRnd);
    }
    void RandomChoose(){
        while(buttonL[0].gameObject.GetComponent<LvButtonId>().bonusRnd == buttonL[1].gameObject.GetComponent<LvButtonId>().bonusRnd){
            buttonL[1].gameObject.GetComponent<LvButtonId>().bonusRnd = Random.Range(0,5);
        }
        while(buttonL[1].gameObject.GetComponent<LvButtonId>().bonusRnd == buttonL[2].gameObject.GetComponent<LvButtonId>().bonusRnd){
            buttonL[2].gameObject.GetComponent<LvButtonId>().bonusRnd = Random.Range(0,5);
        }
        while(buttonL[2].gameObject.GetComponent<LvButtonId>().bonusRnd == buttonL[0].gameObject.GetComponent<LvButtonId>().bonusRnd){
            buttonL[0].gameObject.GetComponent<LvButtonId>().bonusRnd = Random.Range(0,5);
        }
    }

    public void GetBonus(){
        switch(buttonL[lvBtnId].gameObject.GetComponent<LvButtonId>().bonusRnd){
            case 0 :
                Enemy.coinRate += 1;
                GameManager.isLvSet = false;
                break;
            case 1 :
                Bullet.bonusDmg *= 1.5f;
                GameManager.isLvSet = false;
                break;
            case 2 :
                PlayerMove.maxSpeed += 0.5f;
                GameManager.isLvSet = false;
                break;
            case 3 :
                Enemy.coinValue += 1;
                GameManager.isLvSet = false;
                break;
            case 4 :
                PlayerMove.DropRateIncrease *= 1.2f;
                GameManager.isLvSet = false;
                break;
        }
    }

    public void onClickButton0(){
        Debug.Log(buttonL[lvBtnId].gameObject.GetComponent<LvButtonId>().bonusRnd + "눌러진 버튼의 숫자");
    }
}
