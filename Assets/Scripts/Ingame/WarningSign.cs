using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningSign : MonoBehaviour
{
    public TextMeshProUGUI warning;
    float curCol;

    void Update(){
        ChangeColor();
    }

    void ChangeColor(){
        curCol += Time.deltaTime;
        if((int)curCol % 2 == 0){
            warning.color = new Color (255f,255f,255f);
        }else if ((int)curCol % 2 == 1){
            warning.color = new Color (255f,0f,0f);
        }
        if(curCol > 4){
            gameObject.SetActive(false);
        }
    }
}
