using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pressToAttack;
    public Transform wallTransform;
    private float distanceToWall;

    public GameObject Panel;

    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        pressToAttack.gameObject.SetActive(false);

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