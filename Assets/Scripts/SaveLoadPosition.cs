using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPosition : MonoBehaviour
{
    public Vector3 playerPosition;

    private void Start()
    {
        LoadPlayerPosition();
    }


    public void Save()
    {
        playerPosition = transform.position;
        PlayerPrefs.SetFloat("PlayerX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerZ", playerPosition.z);
        PlayerPrefs.Save();
        Debug.Log("Player position saved!");
    }

    public void LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float z = PlayerPrefs.GetFloat("PlayerZ");
        playerPosition = new Vector3(x, y, z);
        transform.position = playerPosition;
        Debug.Log("Player position loaded!");
    }
}