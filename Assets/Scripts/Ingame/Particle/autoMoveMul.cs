using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMoveMul : MonoBehaviour
{
    public int sqrId;
    float rot;
    public int rotspeed;
    public int set38Angle;
    Transform target;
    public Transform child;



    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartRotate();
    }
    void Update()
    {
        Rotate();
    }


    void StartRotate(){
        if(sqrId >= 0 && sqrId <= 36){
            transform.rotation = Quaternion.Euler(0,0,sqrId * 10);
        }else if(sqrId == 38){

        }

    }

    void Rotate(){
        rot = Time.deltaTime * 100f;
        if(sqrId >= 0 && sqrId <= 36){
            transform.Rotate(new Vector3(0,0,rot));
        }
        if(sqrId == 37){
            if(target != null){
                Vector2 direction = new Vector2(
                    transform.position.x - target.position.x,
                    transform.position.y - target.position.y);
                float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(transform.rotation,angleAxis,rotspeed * Time.deltaTime);
                transform.rotation = rotation;
                child.transform.LookAt(target);
            }
        }
        if(sqrId == 38){
            transform.rotation = Quaternion.Euler(0,0,set38Angle);
            child.transform.rotation= Quaternion.Euler(set38Angle,-90,0);
        }
    }
}
