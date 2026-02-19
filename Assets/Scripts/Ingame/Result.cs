using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result : MonoBehaviour
{
    [Header("RusultAsset")]
    PlayerMove playerinfo;
    public GameObject player;
    public TextMeshProUGUI[] scoreText;
    public TextMeshProUGUI[] coinText;
    public TextMeshProUGUI[] doingTimeText;
    public TextMeshProUGUI[] highTimeText;
    private float doingtime;
    private float hightime = 0f;
    
    
    void Start()
    {
        playerinfo = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTimeLogic();
    }

    void ScoreTimeLogic(){
        scoreText[0].text = string.Format("{0:n0}",playerinfo.score);
        scoreText[1].text = string.Format("{0:n0}",playerinfo.score);
        coinText[0].text = PlayerMove.coin.ToString();
        coinText[1].text = PlayerMove.coin.ToString();

        doingTimeText[0].text = Mathf.Ceil(doingtime).ToString() + "  Sec.";
        doingTimeText[1].text = Mathf.Ceil(doingtime).ToString() + "  Sec.";
        highTimeText[0].text = Mathf.Ceil(hightime).ToString() + "  Sec.";
        highTimeText[1].text = Mathf.Ceil(hightime).ToString() + "  Sec.";
        if(PlayerMove.isDead == false){
            doingtime += Time.deltaTime;
        }else{
            if(hightime < doingtime){
                hightime = doingtime;
            }
            // doingtime = 0f;
        }
    }


}
