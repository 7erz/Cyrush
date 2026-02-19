using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBossEffect : MonoBehaviour
{
    float times;
    Transform runaway;
    public static bool isDisBossEff = false;
    void Start()
    {
        runaway = GameObject.FindGameObjectWithTag("RunAway").GetComponent<Transform>();
    }

    void Update()
    {
        if(PlayerMove.isDead ==false){
            times += Time.deltaTime;
        }
        AppearBossEffect();
    }

    void AppearBossEffect(){
        if((int)times > 121){
            transform.position = Vector2.MoveTowards(transform.position,runaway.position,3 * Time.deltaTime);
            Invoke("DisapearChild",5);
        }
    }


    void DisapearChild(){
        gameObject.SetActive(false);
        isDisBossEff = true;
    }
}
