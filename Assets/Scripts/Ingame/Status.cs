using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    [Header("StatusAsset")]
    PlayerMove playerStatus;
    public GameObject player;
    public TextMeshProUGUI Dmg;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI DropRate;
    public TextMeshProUGUI CoinDropRate;
    public TextMeshProUGUI CoinBonus;

    void Start()
    {
        playerStatus = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        currentStatus();
    }

    void currentStatus(){
        Dmg.text = "+" + Bullet.bonusDmg.ToString();
        Speed.text = PlayerMove.maxSpeed.ToString();
        DropRate.text = playerStatus.dropRateTotal.ToString("F2") + "%";
        CoinDropRate.text = Enemy.coinRate.ToString("F2") + "%";
        CoinBonus.text = "+" + Enemy.coinValue.ToString();
    }
}