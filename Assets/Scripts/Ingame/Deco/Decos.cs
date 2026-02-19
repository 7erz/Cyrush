using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decos : MonoBehaviour
{
    Rigidbody2D rigid;
    GameManager gameManager;
    public float decoSpeed;
    public GameObject sign01;
    public GameObject telepole;
    public GameObject smallMountain;
    public GameObject overCactus;
    public GameObject overTree;

    public GameObject player;
    public ObjectManager objectManager;

    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start(){
        gameManager = GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "BorderDeco")
            gameObject.SetActive(false);    //BorderDeco벽에 피격시 파괴
    }
    void Update(){
        moveDecoControl();
    }

    void Moving(){
        transform.position = transform.position + new Vector3(0,0,-0.0001f);
        transform.Translate(new Vector3((Time.deltaTime * decoSpeed)*-1,0,0));
    }
    void moveDecoControl(){
        if(PlayerMove.isDead == false){
            Moving();
        }
    }
}
