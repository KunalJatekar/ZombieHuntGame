using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimController : MonoBehaviour {

    public Animator animator;

    public bool dead = false;
    public float delay;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {

       
    }

    public void Attack()
    {
        animator.SetBool("InRange", true);
        Debug.Log("Attack Sucess");
    }

    public void NotAttack()
    {
        animator.SetBool("InRange", false);
        Debug.Log("NotAttack Sucess");
    }

    public void Death()
    {
        dead = true;
        animator.SetFloat("Health", 0);
        
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length);
        Debug.Log("Death Sucess");
    }

    public void NotDeath()
    {
        animator.SetFloat("Health", 100);
        Debug.Log("NotDeath Sucess");
    }

    public void delete()
    {
        animator.GetBool("HealthToCheck");
        Destroy(gameObject);
    }

	 public void idel()
	 {
			animator.SetFloat("Speed", 0);
	 }

	 public void Walking()
	 {
			animator.SetFloat("Speed", 3);
			Debug.Log("Walk");
	 }
}
