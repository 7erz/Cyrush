using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    
    public float maxShotDelay;
    public float curShotDelay;
    float angle, overAngle;
    public Transform firePos;
    public WeaponManager weaponManager;
    public GameManager gameManager;
    public ObjectManager objectManager;
    public VariableJoystick joy;
    public Transform child;
    
    // public AudioClip audioPbullet;
    // public AudioClip auidoHbullet;
    // public AudioClip audioEbullet;
    // public AudioClip audioRocket;
    // public AudioClip audioBullet;

    public List<AudioClip> audioBullet = new List<AudioClip>();

    
    Vector2 target, mouse;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {

        target = transform.position;
        Aim();
    }
    void Update()
    {
        Aim();
        Fire();
        Reload();
    }

     public void Aim(){
        //스크린 좌표 입력후 월드 좌표로 변환
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //탄젠트 y/x값을 가지는 라디안을 반환
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        if(angle > -25 && angle < 45) {     //회전 각도 제한
            this.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }else if(angle <= -25){
            overAngle = -25;
        }else if(angle >= 45){
            overAngle = 45;
        }
    }

    void Fire(){
        //발사 조건
        if(!Input.GetButton("Fire1"))       //안누르면 격발 안됨
            return;
        if(curShotDelay < maxShotDelay)     //발사속도를 넘지 못하면 발사안됨
            return;
        if(angle == -180 && angle == 180)   //각도를 넘어가면 안됨
            return;
        //총알 생성
        if(child.gameObject.activeSelf && Input.GetButton("Fire1")){
            switch(WeaponManager.WeaponNum)     //weaponManager.WeaponNum 으로 수정바람 테스트중
            {
                case 0:
                    maxShotDelay = 0.2f;
                    GameObject Pbullet = objectManager.MakeObj("PBullet");
                    Pbullet.transform.position = transform.position;
                    Pbullet.transform.rotation = Quaternion.identity;
                    if(angle > -25 && angle < 45){
                        Pbullet.transform.eulerAngles = new Vector3(0,0,angle);
                    }else if(angle <= -25 && angle >= -180){
                        Pbullet.transform.eulerAngles = new Vector3(0,0,overAngle);
                    }else if(angle >= 45 && angle <= 180){
                        Pbullet.transform.eulerAngles = new Vector3(0,0,overAngle);
                    }
                    Rigidbody2D Prigid = Pbullet.GetComponent<Rigidbody2D>();
                    Prigid.linearVelocity = firePos.right * 40;
                    PlaySound();
                    break;
                case 1:
                    maxShotDelay = 0.1f;
                    GameObject Hbullet = objectManager.MakeObj("HBullet");
                    Hbullet.transform.position = transform.position;
                    Hbullet.transform.rotation = Quaternion.identity;
                    if(angle > -25 && angle < 45){
                        Hbullet.transform.eulerAngles = new Vector3(0,0,angle);
                    }else if(angle <= -25 && angle >= -180){
                        Hbullet.transform.eulerAngles = new Vector3(0,0,overAngle);
                    }else if(angle >= 45 && angle <= 180){
                        Hbullet.transform.eulerAngles = new Vector3(0,0,overAngle);
                    }
                    Rigidbody2D Hrigid = Hbullet.GetComponent<Rigidbody2D>();
                    Hrigid.linearVelocity = firePos.right * 45;
                    PlaySound();
                    break;
                case 2:
                    maxShotDelay = 0.07f;
                    GameObject Ebullet = objectManager.MakeObj("EBullet");
                    Ebullet.transform.position = transform.position;
                    Ebullet.transform.rotation = Quaternion.identity;
                    if(angle > -25 && angle < 45){
                        Ebullet.transform.eulerAngles = new Vector3(0,0,angle);
                    }else if(angle <= -25 && angle >= -180){
                        Ebullet.transform.eulerAngles = new Vector3(0,0,overAngle);
                    }else if(angle >= 45 && angle <= 180){
                        Ebullet.transform.eulerAngles = new Vector3(0,0,overAngle);
                    }

                    Rigidbody2D Erigid = Ebullet.GetComponent<Rigidbody2D>();
                    Erigid.linearVelocity = firePos.right * 42;
                    PlaySound();
                    break;
                case 3:
                    maxShotDelay = 0.3f;
                    GameObject rocket = objectManager.MakeObj("Rocket");
                    rocket.transform.position = transform.position;

                    Rigidbody2D Rrigid = rocket.GetComponent<Rigidbody2D>();
                    Rrigid.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
                    break;
            }
        }
        curShotDelay = 0;
    }

    void Reload(){
        if(PlayerMove.isDead == false || GameManager.isLvSet == false || GameManager.isMenu == false || PlayerMove.isDead == false)
            curShotDelay += Time.deltaTime;
    }

    void PlaySound(){
        AudioClip clip = audioBullet[Random.Range(0,audioBullet.Count)];
        audioSource.PlayOneShot(clip);
        audioSource.Play();
    }

    // void bulletShell(){ //탄피
    //     GameObject bs1 = objectManager.MakeBs("BS");
    //     bs1.transform.position = transform.position;

    //     Rigidbody2D bS1rigid = bs1.GetComponent<Rigidbody2D>();
    //     bS1rigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
    // }
}
