using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonrise : MonoBehaviour
{   
    [Header("MoonSettings")]
    int index;
    float times;
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    Transform runaway;

    [Header("Shake")]
    bool shaking = false;
    [SerializeField]
    float shakeAmt;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        // DebugShake();
        spriteRenderer.sprite = sprites[index];
        if(PlayerMove.isDead ==false){
            times += Time.deltaTime;
        }
        MoonCheck();
        MoonShake();
        ShakeMoonDebug();

    }

    void MoonCheck(){
        if((int)times % 10 == 0){
            index = (int)times / 10;
        }
        if(index > 11){
            index = 11;
        }
    }

    void MoonShake(){
        if(index == 11 && (int)times > 121){
            StartCoroutine("ShakeNow");
        }
    }

    void DisapearChild(){
        gameObject.SetActive(false);
    }

    void ShakeMoonDebug(){
        if(shaking){
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }
    IEnumerator ShakeNow(){
        Vector3 originalPos = transform.position;
        if(shaking == false)
            shaking = true;

        yield return new WaitForSeconds(2.5f);

        shaking = false;
        transform.position = originalPos;
    }
}
