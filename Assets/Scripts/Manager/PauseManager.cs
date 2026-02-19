using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void Pause(){
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void Resume(){
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
