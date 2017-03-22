using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public float pndRad;
    public float pndDmg;
    public float pndSpd;

    public float bashRad;
    public float bashDmg;
    public float bashSpd;
    
    public bool isAttacking;
    public bool pound;
    public bool bash;
    
    HeadMovement moveScript;
    GroundCheck groundCheck;
    GameObject head;
    // Use this for initialization
    void Start()
    {
        moveScript = GameObject.Find("Player").GetComponent<HeadMovement>();
        groundCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();
        head = GameObject.Find("Player");
        isAttacking = false;
        pound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pound == true || bash == true)
        {    
            isAttacking == true;   
        }
        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)) && !isAttacking)
        {
            pound = true;
        }

        if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)) && !isAttacking)
        {
            pound = true;
        }
        Pound();
    }

    private void Pound()
    {
        if(groundCheck.grounded == false && pound == true)
        {
            head.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -pndSpd);
        }
        if(groundCheck.grounded == true && pound == true)
        {
            pound = false;
        }
    }

}
