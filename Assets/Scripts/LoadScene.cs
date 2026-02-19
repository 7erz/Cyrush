using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void update(){
        StartGameScene();
    }
    public void StartGameScene(){
        LoadingSceneManager.LoadScene("InGame");
    }
    public void EndGameScene(){
        LoadingSceneManager.LoadScene("Menu");
    }
}
