using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField]
    private TMP_Text pressToAttack;
    public Transform wallTransform;
    private float distanceToWall;

    public GameObject Panel;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pressToAttack.gameObject.SetActive(false);

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.velocity = movement * speed;

     
    }
    private void Update(){

        if (wallTransform != null)
        {
            distanceToWall = Vector3.Distance(transform.position, wallTransform.position);
            if (distanceToWall <= 7){
   if (Input.GetKeyUp(KeyCode.F))
                {
                    Debug.Log("pressed F");
                    OpenPanel();
                }
                pressToAttack.gameObject.SetActive(true);
             
            }
            else{
                pressToAttack.gameObject.SetActive(false);
                Panel.SetActive(false);
            }
        }


    }

 public void OpenPanel(){
    if (Panel != null){
        bool isActive = Panel.activeSelf;
        Panel.SetActive(!isActive);
    }
 }

  
}