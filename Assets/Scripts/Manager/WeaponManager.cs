using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static int WeaponNum;
    public PlayerMove playerMove;
    public GameObject Pistol;
    public GameObject Ak47;
    public GameObject Avivo;
    void Start(){
        // DontDestroyOnLoad(gameObject);
        // Debug.Log(transform.GetChild(ButtonInfoID.setId).name);
    }

    public void currentWea(){
        // Debug.Log(WeaponNum);
    }

    void Update(){
        cTest();
        GunStatus();
    }



    void cTest(){
        if(Input.GetKeyDown(KeyCode.Alpha1))
            WeaponNum = 0;
        if(Input.GetKeyDown(KeyCode.Alpha2))
            WeaponNum = 1;
        if(Input.GetKeyDown(KeyCode.Alpha3))
            WeaponNum = 2;
    }
    void GunStatus(){
        switch(WeaponNum){
            case 0:
                Pistol.gameObject.SetActive(true);
                break;
            case 1:
                Pistol.gameObject.SetActive(false); 
                Ak47.gameObject.SetActive(true);
                break;
            case 2:
                Ak47.gameObject.SetActive(false);
                Avivo.gameObject.SetActive(true);
                break;
        }
    }
}
