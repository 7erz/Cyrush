using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAlpha : MonoBehaviour
{
    public GameObject playerObj;
    SpriteRenderer spriteRenderer;
    float Dist;
    float alpha;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAlpha();
        Test();
    }

    void ChangeAlpha(){
        Dist = Vector2.Distance(transform.position, playerObj.transform.position);
        alpha = 255 / Dist;
        if(alpha > 100){
            alpha = 100;
        }else if(alpha < 70){
            alpha = 0;
        }
        spriteRenderer.color = new Color(255/255f,0/255f,251/255f,alpha/255f);
    }

    void Test(){
        if(Input.GetKey(KeyCode.F)){
            Debug.Log("Dist = " + Dist);
            Debug.Log("alpha = " + alpha);
        }
    }
}
