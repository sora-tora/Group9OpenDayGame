using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TwoEntityCamera : MonoBehaviour
{
    public List<Transform> targets;
 
    public Vector3 offset = new Vector3 (0,2,-2);
    public float smoothTime = .2f;
 
    public float minZoom = 8f;
    public float maxZoom = 5f;
    public float zoomLimiter = 125f;
 
    private Vector3 velocity;
    private Camera cam;
 
 
    private void Start()
    {
 
        cam = GetComponent<Camera>();
 
    }
 
    private void LateUpdate()
    {
 
        if (targets.Count == 0)
            return;
 
 
        move();
        zoom();
 
    }
 
    void zoom()
    {
 
        float newZoom = Mathf.Lerp(maxZoom, minZoom, getGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
 
 
    }
 
 
    void move()
    {
 
        Vector3 centerPoint = getCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
 
    }
 
    float getGreatestDistance()
    {
 
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
 
            bounds.Encapsulate(targets[i].position);
 
 
        }
 
        return bounds.size.x;
 
    }
 
 
    Vector3 getCenterPoint()
    {
 
        if (targets.Count == 1)
        {
 
            return targets[0].position;
 
 
        }
 
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
 
 
            bounds.Encapsulate(targets[i].position);
 
        }
 
        return bounds.center;
 
 
    }
 
 
}

