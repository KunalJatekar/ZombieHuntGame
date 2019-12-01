using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    public AnimatorOverrideController controller;
     
	void Start ()
    {
        controller = GetComponent<AnimatorOverrideController>();
	}
	
	void Update ()
    {
		
	}
}
