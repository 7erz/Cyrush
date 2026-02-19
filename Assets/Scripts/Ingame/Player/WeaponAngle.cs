using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAngle : MonoBehaviour
{

    public float angle;
    float result;

    public GameManager gameManager;
    public ObjectManager objectManager;
    Vector2 target, mouse, bMouse;

    void Start()
    {
        target = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    public void Aim(){
        //스크린 좌표 입력후 월드 좌표로 변환
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //탄젠트 y/x값을 가지는 라디안을 반환
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        //물체의 각도 회전
        if(angle > -25 && angle < 45) {     //회전 각도 제한
            this.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
    }

}
