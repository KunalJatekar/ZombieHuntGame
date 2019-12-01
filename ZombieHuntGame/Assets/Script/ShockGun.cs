using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShockGun : MonoBehaviour
{

     float dir;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dir, 0, 0);
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length);
    }

    public void Shootdirection(float direction)
    {
        dir = direction;

        transform.localScale = new Vector3(dir * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");       
    }
}
