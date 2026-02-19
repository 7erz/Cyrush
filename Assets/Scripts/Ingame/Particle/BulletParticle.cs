using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public bool isDebug;
    public float maxShotDelay;
    public float curShotDelay;
    public ParticleSystem autoParticleSystem;
    public ParticleSystem targetParticleSystem;
    public ParticleSystem strParticleSystem;
    public float psEmission;    //startspeed도 비슷하게 바꿔보자
    int firespeed;
    int startspeed;
    // int bossLaserfire;
    // int bossLaserSpeed;
    HitBox hitBox;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    private void Start() {
        hitBox = GetComponent<HitBox>();
        autoParticleSystem = GetComponent<ParticleSystem>();
        targetParticleSystem = GetComponent<ParticleSystem>();
        strParticleSystem = GetComponent<ParticleSystem>();
    }
    private void Update() {
        fireRate();
        Fire();
        Reload();
    }

    private void OnParticleCollision(GameObject other) {
        int evnets = autoParticleSystem.GetCollisionEvents(other, colEvents);
        if(other.TryGetComponent(out PlayerMove pm)){
            pm.PlayerDead();
        }
    }

    void Fire(){
        if(autoParticleSystem.isPlaying || targetParticleSystem.isPlaying || strParticleSystem.isPlaying){
            Debug.Log("지금 실행중입니다.");
            return;
        }
    }

    public void FireAuto(){     //흩뿌리기
        autoParticleSystem.Play();
    }
    public void FireTarget(){    //플레이어 추적 발사
        targetParticleSystem.Play();
    }
    public void FireStr(){      //수직발사
        strParticleSystem.Play();
    }
    void Reload(){
        curShotDelay += Time.deltaTime;
    }

    void fireRate(){
        if(isDebug == true){
            Debugspeed();
        }else{
            firespeed = GameManager.PLv;
            startspeed = GameManager.PLv;
            // bossLaserfire = 1;
            // bossLaserSpeed = 1;
        }
        var emission = autoParticleSystem.emission;
        emission.rateOverTime = firespeed;

        // var emissionBoss = autoParticleSystem.emission;
        // emissionBoss.rateOverTime = bossLaserfire;

        var main = autoParticleSystem.main;
        main.startSpeed = startspeed;

        // var mainBoss = autoParticleSystem.main;
        // mainBoss.startSpeed = bossLaserSpeed;


        if(firespeed < 1){
            Debug.Log("1 미만으로 변경할수 없습니다");
            firespeed = 1;
            startspeed = 1;
        }else if(firespeed > 30){
            Debug.Log("30을 초과할수 없습니다");
            firespeed = 30;
            startspeed = 30;
        }
    }

    void Debugspeed(){
        if(Input.GetKeyDown(KeyCode.W)){
            print(firespeed + "," + startspeed);
            firespeed += 1;
            startspeed += 1;
        }else if(Input.GetKeyDown(KeyCode.S)){
            print(firespeed + "," + startspeed);
            firespeed -= 1;
            startspeed -= 1;
        }
    }
}
