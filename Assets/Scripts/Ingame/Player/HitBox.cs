using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public bool isGod, isHitbox;
    public GameManager gameManager;
    public Vector3 followPos;
    public Transform parent;
    public Transform child;
    public Queue<Vector3> parentPos;
    Animator anim;
    
    void Start() {
        anim = GetComponent<Animator>();
    }
    void Update(){
        Watch();
        Follow();
    }
    void Watch(){   //따라갈 위치
        followPos = parent.position;
    }
    void Follow(){
        if(isHitbox)
            transform.position = followPos + new Vector3(0.08f,0.1f,0);
        else{
            transform.position = followPos - new Vector3(20,0,0);
        }
    }
    public void PlayerDead(){
        PlayerMove.isDead = true;
    }

    void OnTriggerEnter2D(Collider2D collision){    //충돌 처리 
        if(isGod == false){
            if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet"){
                PlayerDead();
                child.gameObject.SetActive(false);
            }
            else if(collision.gameObject.tag == "Item"){
                Item item = collision.gameObject.GetComponent<Item>();
                switch(item.type){
                    case "Coin": 
                        break;
                    case "Bomb":
                        break;
                }
            }
        }
    }
}
