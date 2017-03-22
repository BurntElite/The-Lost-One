using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public float atkRad;
    public float atkDmg;
    public float poundSpd;

    public bool isAttacking;
    public bool pound;

    GroundCheck groundCheck;
    GameObject head;
    // Use this for initialization
    void Start()
    {
        groundCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();
        head = GameObject.Find("Player");
        isAttacking = false;
        pound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)) && !isAttacking)
        {
            pound = true;
        }

        Pound();
    }

    private void Pound()
    {
        if(groundCheck.grounded == false && pound == true)
        {
            head.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -poundSpd);
        }
        if(groundCheck.grounded == true && pound == true)
        {
            pound = false;
        }
    }

}
