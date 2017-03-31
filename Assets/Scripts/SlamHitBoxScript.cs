using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamHitBoxScript : MonoBehaviour
{
    GameObject Player;
    Slam slamScript;
    GameObject[] Enemies;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        slamScript = Player.GetComponent<Slam>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = slamScript.enemies;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(GameObject Enemy in Enemies)
        {
            if(Enemy == collision.gameObject)
            {
                Enemy.GetComponent<EnemyBaseScript>().slam = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach(GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<EnemyBaseScript>().slam = false;
        }
    }

}
