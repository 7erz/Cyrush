using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCoinSaver : MonoBehaviour
{
    public TextMeshProUGUI haveCoinText;
    
    void Awake() {
    }
    void Update(){
        haveCoinText.text = CoinShow.haveCoin.ToString();
        DebugCoin();
    }

    public void DebugCoin(){
        if(Input.GetKey(KeyCode.F4)){
            print("haveCoin: "+CoinShow.haveCoin);
        }
    }



}
