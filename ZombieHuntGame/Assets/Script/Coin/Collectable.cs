	 using System.Collections;
	 using System.Collections.Generic;
	 using UnityEngine;
	 using UnityEngine.UI;
	 using Newtonsoft.Json;

	 public class Collectable : MonoBehaviour {

			 public Text countText;
			 public static int count=0;
			public new AudioSource audio;

			void Start ()
			 {
				 audio = GetComponent<AudioSource>();
			}

		 void Update ()
		 {
        
		 }

			 private void OnTriggerEnter2D(Collider2D collision)
			 {
					 if (collision.gameObject.CompareTag("Player"))
					 {
							
							 count = count + 1;
							 countText.text = "Count" + count;
							 gameObject.SetActive(false);
							 
					 }
			 }


	 }
