using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{   
    //씬이 전환될 때 데이터 값을 지워지지 않고 넘기게 해주는 함수
    //씬이 전환되면 그 씬의 모든 오브젝트는 지워지고 정보는 삭제된다.
    public static MainManager Instance;
    private void Awake(){
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
