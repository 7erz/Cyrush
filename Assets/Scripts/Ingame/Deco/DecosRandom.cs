using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecosRandom : MonoBehaviour
{
    Rigidbody2D rigid;
    GameManager gameManager;

    public GameObject cactus01;
    public GameObject cactus02;
    public GameObject drum01;
    public GameObject drum02;
    public GameObject tree01;
    
    float decoSpeed;

    public GameObject player;
    public ObjectManager objectManager;

    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start(){
        gameManager = GetComponent<GameManager>();
    }
    void OnEnable() { 
        switch(GameManager.ranDPoint){
            case 0:
                decoSpeed = 2f;
                transform.GetComponent<SpriteRenderer>().sortingOrder = -2;
                break;
            case 1:
                decoSpeed = 3.5f;
                transform.GetComponent<SpriteRenderer>().sortingOrder = -1;
                break;
            case 2:
                decoSpeed = 6.5f;
                transform.GetComponent<SpriteRenderer>().sortingOrder = 5;
                break;
            case 3:
                decoSpeed = 9f;
                transform.GetComponent<SpriteRenderer>().sortingOrder = 6;
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "BorderDeco")
            gameObject.SetActive(false);    //BorderDeco벽에 피격시 파괴
    }
    void Update(){
        LaneDecoControl();
    }

    void LaneDecoControl(){
        if(PlayerMove.isDead == false){
            transform.Translate(new Vector3((Time.deltaTime * decoSpeed)*-1,0,0));
        }
    }
}