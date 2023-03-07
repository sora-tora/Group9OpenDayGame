using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManagement : MonoBehaviour
{
    private SaveLoadPosition playerMovement;
    public void Start(){
        playerMovement = GameObject.FindObjectOfType<SaveLoadPosition>();
    }
    public void LoadScene(string sceneName){
        playerMovement.Save();
        SceneManager.LoadScene(sceneName);
    }

    public void Return(string name){
        SceneManager.LoadScene(name);
        playerMovement.LoadPlayerPosition();
    }
}
