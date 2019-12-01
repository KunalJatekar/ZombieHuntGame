using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 offset;
    Vector2 charscale;
    public float range;
    public GameObject player;
    public Animator animator;
    public BoxCollider2D box;
    public bool rang = false;
    public float miniDistance;

    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {

        if (rang == true)
        {
            animator.SetBool("Range", true);
        }

        if (rang == false)
        {
            animator.SetBool("Range", false);
        }

        if (offset.x < miniDistance)
        {
            
        }

        offset = transform.position - player.transform.position;
        charscale = transform.localScale;
        if (range < offset.x)
        {
            charscale.x = 1f;
        }
        if (range > offset.x)
        {
            charscale.x = -1f;
        }
        transform.localScale = charscale;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            rang = true;   
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            rang = false;
        }
    }

}
