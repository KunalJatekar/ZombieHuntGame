using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulletspeed : MonoBehaviour {

    public float movespeed=6;
   public float dir;
	 
	void Start ()
	{
	 		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += new Vector3(dir, 0,0) * movespeed * Time.deltaTime;
    }

    public void Shootdirection(float direction)
    {
        dir = direction;
        transform.localScale = new Vector3(dir*transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered");
        Destroy(gameObject);
    }
}
