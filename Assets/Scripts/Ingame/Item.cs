using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    Rigidbody2D rigid;
    Enemy itemList;
    GameManager gameManager;
    PlayerMove player;
    Enemy enemy;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMove>();
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        rigid.linearVelocity = Vector2.left * 3.0f;
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "BorderItem")
            gameObject.SetActive(false);
        if(collision.gameObject.tag == "BorderItemGet"){
            gameObject.SetActive(false);
            //아이템 획득 시 로직
        }
    }

    
}
