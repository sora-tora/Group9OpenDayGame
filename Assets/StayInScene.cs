using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInScene : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
