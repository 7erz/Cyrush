using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LvBar : MonoBehaviour
{
    public Slider xpBar;
    PlayerMove playerLv;
    public GameObject player;
    public TextMeshProUGUI LvText;
    void Start()
    {
        playerLv = player.GetComponent<PlayerMove>();
        LvText.GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        Progress();
    }

    void Progress(){
        LvText.text = GameManager.PLv.ToString();
        xpBar.value = playerLv.curExp / playerLv.maxExp;
    }
}
