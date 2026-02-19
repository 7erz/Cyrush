using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : MonoBehaviour
{
    public GameObject Laser;
    PlayerMove pm;

    LineRenderer lr;

    void Start(){
        pm = GetComponent<PlayerMove>();
        lr = Laser.GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    void Update(){
        if(lr.enabled){
            Physics.Raycast (transform.position,transform.forward, out RaycastHit hit);

            if(hit.transform.CompareTag("Player")){
                pm.PlayerDead();
            }
        }
    }
}
