using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    public Animationp animationp;
    public Rigidbody2D rb;
    public Movement movement;
    public CapsuleCollider2D capsule;
    public BoxCollider2D box;

    public GameObject levelFailed;

    public Joystiick joystiick;


    public bool alive = true;

    public float currentHealth=100;
    public float maxHealth=100;
    public float damage = 0.5f;
    public float damageofSnake = 0.1f;

	
	void Start ()
    {
        slider.value = maxHealth;
        animationp = GetComponent<Animationp>();
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        joystiick = FindObjectOfType<Joystiick>();

        box = GetComponent<BoxCollider2D>();

    }


    public void Update()
    {
        if (transform.position.x < 70 && slider.value==0 )
        {
            //Application.Quit();
            levelFailed.SetActive(true);
        }


        if (slider.value == 0)
        {
           animationp.Deadth();
           movement.movespeed = 0;
            alive = false;
        }

        if (alive == false)
        {
            capsule.enabled = false;
            
            box.enabled = true;
            joystiick.Atend();
            joystiick.enabled = false;
        }
        
    }


    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (currentHealth > 0)
            {
                currentHealth = currentHealth - damage;
                slider.value = currentHealth;
            }
            else
            {
                currentHealth = 0;
            }

        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (currentHealth > 0)
            {
                currentHealth = currentHealth - damageofSnake;
                slider.value = currentHealth;
            }
            else
            {
                currentHealth = 0;
            }

        }
    }

}
