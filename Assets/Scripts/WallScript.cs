using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WallScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pressToAttack;
    private bool attackAllowed;
    // Start is called before the first frame update
    void Start()
    {
        pressToAttack.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(attackAllowed && Input.GetKeyDown(KeyCode.F))
            Attack();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Equals("Player")){
            pressToAttack.gameObject.SetActive(true);
            attackAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name.Equals("Player")){
            pressToAttack.gameObject.SetActive(false);
            attackAllowed = false;
        }
    }
    private void Attack(){
        Destroy(gameObject);
    }
}
