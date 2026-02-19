using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    void Awake() {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        //기종의 가로 세로 비율 / 고정비율
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9); 
        float scalewidth = 1f/scaleheight;
        if(scaleheight < 1) //위 아래가 남음
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }else{  //좌 우가 남음
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }
    void OnPreCull() {
        GL.Clear(true,true,Color.black);
    }
}
