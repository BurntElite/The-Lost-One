using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

    public float moveSpd;
    public float jumpSpd;
    public bool facingLeft;

    Rigidbody2D rigid;

    GroundCheck GroundedScript;
	// Use this for initialization
	void Start () {
        GroundedScript = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        facingLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            facingLeft = true;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            Move();
        }
        else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            facingLeft = false;
            transform.localEulerAngles = new Vector3(0, 180, 0);
            Move();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
	}

    private void Move()
    {
        if (facingLeft)
        {
            rigid.velocity = new Vector2(-moveSpd, rigid.velocity.y);
        }
        else if (!facingLeft)
        {
            rigid.velocity = new Vector2(moveSpd, rigid.velocity.y);
        }
    }
    private void Jump()
    {
        if (GroundedScript.grounded == true)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpSpd);
        }
    }

}
