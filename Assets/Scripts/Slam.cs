using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour {

    //Variables
    private float slamAtk;
    private float slamRad;
    private float slamForce = 20;
    private float cooldownTime;

    public bool isSlam;
    public bool isCooldown;

    //Objects

    public GameObject head;
    public GameObject[] enemies;
    public GameObject hitBox;
    public GameObject GroundChecker;

    public GroundCheck groundCheckScript;

	//Start
	void Start () {
        slamRad = 2.5f;

        isSlam = false;
        isCooldown = false;

        head = GameObject.Find("Player");
        hitBox = GameObject.Find("slamHitBox");

        GroundChecker = GameObject.Find("CheckGroundObj");
        groundCheckScript = GroundChecker.GetComponent<GroundCheck>();
        hitBox.GetComponent<CircleCollider2D>().radius = slamRad;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	//Update
	void Update () {

        cooldownTime -= Time.deltaTime;

        if(Input.GetKey(KeyCode.S) && !isCooldown && !isSlam)
        {
            isSlam = true;
        }

        slamInit();
        slamCooldown();
	}

    //Initiates Slam
    private void slamInit()
    {
        if(isSlam == true)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (groundCheckScript.grounded == false)
            {
                head.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -slamForce);
            }
            else if(groundCheckScript.grounded == true)
            {
                DamageInit();

                cooldownTime = 3f;
                isCooldown = true;
            }
        }
    }

    private void slamCooldown()
    {
        if(isCooldown == true)
        {
            if(cooldownTime < 0)
            {
                isCooldown = false;
            }
        }
    }

    private void DamageInit()
    {

        foreach (GameObject Enemy in enemies)
        {
            if(Enemy.GetComponent<EnemyBaseScript>().slam == true)
            {
                Destroy(Enemy.gameObject);
                
            }
        }

        
        isSlam = false;
    }

}