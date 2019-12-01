using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadCamera : MonoBehaviour {

    public Vector3 offset;
    public Material material;
   public float speed;
	void Start ()
    {
        offset = new Vector3(Time.deltaTime * speed, 0);
    }


    void Update()
    {
        material.mainTextureOffset = offset ;
    }
}
