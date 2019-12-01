using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Transform shootpoint;
    public Transform sshockshoot;
    public GameObject bullet;
    public GameObject shock;
    public Animationp animationp;

    public Gamemanager gamemanager;

    public float delay;
    public float movespeed;


	
	void Start ()
    {
	    shootpoint= transform.GetChild(0);
        animationp = GetComponent<Animationp>();
        gamemanager = FindObjectOfType<Gamemanager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            delay = 30;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            delay = 30;
            Shock();
        }
    }

    public void Shoot()
    {
        if (animationp.dead == false)
        {
            GameObject gobj = Instantiate(bullet, shootpoint.position, Quaternion.identity);
            gobj.GetComponent<Bulletspeed>().Shootdirection(Mathf.Sign(transform.localScale.x));
        }

    }

    public void Shock()
    {
        if (animationp.dead == false)
        {
            gamemanager.pressed = true;
            GameObject gobj = Instantiate(shock, sshockshoot.position, Quaternion.identity);
        }
    }
}
