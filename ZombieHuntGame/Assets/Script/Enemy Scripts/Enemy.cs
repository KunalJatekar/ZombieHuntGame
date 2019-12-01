using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public bool InRange = true;
    //public Transform limitofmove;
    //public float limit;

    //public Transform[] AttackRange;

    public float minDistance;
    //public Transform target;

    float moveSpeed =3;

    public Vector3 offset;
    public float range;
    
    public ZombieAnimController anim;

    public Animation play;
    public Vector3 charscale;
    public Animationp animationp;

    public BoxCollider2D box;
    public CapsuleCollider2D capsule;

    public GameObject player;

    public float Delay;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animationp = FindObjectOfType<Animationp>();
       // target = GameObject.FindWithTag("Player").transform;

        anim = GetComponent<ZombieAnimController>();

        box = GetComponent<BoxCollider2D>();
        capsule = GetComponent<CapsuleCollider2D>();

        play = GetComponent<Animation>();

        
    }


    void Update()
    {
        //limit = limitofmove.position.x;
        offset = transform.position - player.transform.position;
        charscale = transform.localScale;
        if (range < offset.x)
        {
            charscale.x = -1f;
        }
        if (range > offset.x)
        {
            charscale.x = 1f;
        }
        transform.localScale = charscale;

			if (offset.x < minDistance && animationp.dead == false)
			{
				 anim.Walking();
				 transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
			}
			else
			{
				 anim.idel();
			}


        if (anim.dead == true)
        {
            box.enabled = false;
            moveSpeed = 0;
        }

        {/*

            range = Vector2.Distance(transform.position, target.position);

            transform.LookAt(target.position );
            transform.Rotate(new Vector3(0, 90, 0), Space.Self);

            if (range < minDistance)
            {
                //transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            }
            */}


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            anim.Death();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shock"))
        {
            anim.Death();
        }



        if (other.gameObject == player)
        {
            InRange = true;
            anim.Attack();
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            InRange = false;
            anim.NotAttack();
        }
    }


}
