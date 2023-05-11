using Minigames.Logan.Minigame1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    List<Transform> transforms = new List<Transform>();

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (LK_TopDownPlayerController cont in FindObjectsOfType<LK_TopDownPlayerController>())
        {
            transforms.Add(cont.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transforms.Count == 0) { foreach (LK_TopDownPlayerController cont in FindObjectsOfType<LK_TopDownPlayerController>()) { transforms.Add(cont.transform); }; };
        Vector3 avg = Vector3.zero;
        for (int i = 0; i < transforms.Count; i++)
        {
            avg += transforms[i].position;
        }
        avg /= transforms.Count;
        avg.z = -10f;
        transform.position = avg;
    }
}
