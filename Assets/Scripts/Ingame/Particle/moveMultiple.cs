using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMultiple : MonoBehaviour
{
    public int sqrId;
    float angle;
    Vector2 target,mouse;
    private void Start() {
        target = transform.position;
    }
    void Update()
    {
        Rotate();
    }

    void Rotate(){
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y,mouse.x - target.x) * Mathf.Rad2Deg;
        switch(sqrId){
            case 0:
            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
            break;
            case 1:
            transform.rotation = Quaternion.AngleAxis(angle+30, Vector3.forward);
            break;
            case 2:
            transform.rotation = Quaternion.AngleAxis(angle+150, Vector3.forward);
            break;
        }
    }
}
