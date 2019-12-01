using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  
    public Transform playerTransform;
    Vector3 Offset;
    public float follow = 0.3f;
    public bool following = false;
    Vector3 velocity;

    void Start()
    {
        Offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.x < 70.35f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(playerTransform.position.x, -2.81f, -10) + Offset, ref velocity, follow);
            //transform.position = Vector3.SmoothDamp(transform.position, playerTransform.position + Offset, ref velocity, follow);
            following = true;
        }
        else
        {
            following = false; 
        }
    }
    

   
}
