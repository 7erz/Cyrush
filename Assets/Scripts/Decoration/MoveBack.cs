using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    //배경을 담당
    public float speed;     //움직일 속도
    public int startIndex;
    public int endIndex;
    public Transform[] sprites; //배경 담아줄 것

    public float finalPos;    //무한배경의 마지막 지점

    private void Awake() {
        // viewHeight = Camera.main.orthographicSize;  //2를 곱해서 실제 높이를 구함
    }
    void Update()
    {
        Move();
        Scrolling();
    }

    void Move(){
        //시간에 따라 이동
        if(PlayerMove.isDead == false){
            Vector3 curpos = transform.position;
            Vector3 nextpos = Vector3.left * speed * Time.deltaTime;
            transform.position = curpos + nextpos;
        }
    }

    void Scrolling(){
        if(sprites[endIndex].position.x < finalPos)
        {   
            Vector3 backSpritesPos = sprites[startIndex].localPosition;
            Vector3 frontSpritesPos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritesPos + Vector3.right*(finalPos*(-1)) + new Vector3(0,0,0.0001f);   //마지막 위치에서 원점으로 되돌림

            //위치가 바뀌는 것을 저장하는 함수
            int startIndexSave = startIndex;        
            startIndex = endIndex;
            endIndex = (startIndexSave-1 == -1) ? sprites.Length-1 : startIndexSave -1;
        }
    }

}
