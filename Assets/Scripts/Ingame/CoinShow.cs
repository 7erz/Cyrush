using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinShow : MonoBehaviour
{
    public static int haveCoin;
    private void Awake() {
        if(PlayerPrefs.HasKey("Coin")){
            PlayerPrefs.GetInt("Coin");
            print("불러옴");
            haveCoin = PlayerPrefs.GetInt("Coin");
        }else{
            PlayerPrefs.SetInt("Coin",0);
            print("첫실행");
            haveCoin = PlayerPrefs.GetInt("Coin");
        }
    }

    void Update(){
        DebugCoin2();
    }
    public void saveCoin(){
        haveCoin += PlayerMove.coin;
        PlayerPrefs.SetInt("Coin",haveCoin);
        PlayerPrefs.Save();
        print("PlayerPrefs: "+PlayerPrefs.GetInt("Coin"));
        print("haveCoin: "+CoinShow.haveCoin);
    }
    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("Coin",haveCoin);
        PlayerPrefs.Save();
        print(haveCoin);
        print("저장");
    }

    public void DebugCoin2(){
        if(Input.GetKey(KeyCode.F5)){
            print("PlayerPrefs: "+PlayerPrefs.GetInt("Coin"));
        }
    }
}