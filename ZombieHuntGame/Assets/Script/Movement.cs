using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float movespeed;
    //public float speed;
    public float jumpforce;
    public Joystiick joystiick;
    public FollowCamera follow;
    public GameObject levelfailed;
    public Gamemanager gamemanager;

    public Image image;

	 public new AudioSource audio;

    float varx;

    float localscalx;

    //float vary;

    Rigidbody2D rb;
    public bool grounded = true;


    public Animationp animationp;


    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animationp = GetComponent<Animationp>();

        gamemanager = FindObjectOfType<Gamemanager>();

			audio = GetComponent<AudioSource>();

        localscalx = transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update ()
    {
        {
            /* #if UNITY_EDITOR
                    varx = Input.GetAxisRaw("Horizontal"); //PreProcessros use Eitor to controll means it will not move through joystick
            #endif 

            #if UNITY_ANDROID
                    varx = joystiick.Horizontal();   //PreProcessros use Android to control means it will move through joystick
            #endif */
        }

        if (transform.position.y < -9)
        {
            gamemanager.Restart();
        }

        varx = joystiick.Horizontal();
        Debug.Log(varx);
        rb.velocity = new Vector2(varx * movespeed, rb.velocity.y);

        Change();
        if (Input.GetKeyDown(KeyCode.G))
        { 
        Jumpstate();
        }

        {
            /*if (Input.GetKeyDown(KeyCode.G) && grounded==true)
            {
                rb.velocity = new Vector2(0, jumpforce);
                animationp.jump();
                animationp.NotIdel();
                grounded = false;  
            }   //jump
            {
                //if (movespeed > 1f)
                //{
                //   speed = 2;
                // }
                //if (movespeed < 1f)
                // {
                //    speed = -1;
                // }
            }//comment windows control*/
        }

        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
        {
            animationp.Run();
            animationp.Fire();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animationp.Fire();
            animationp.NotRun();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animationp.Run();
            animationp.Notfire();
        }
        if (transform.position.x>70)
        {
            //Application.Quit();
            levelfailed.SetActive(true);
           
        }
        

    }

    public void Change()
    {
        Vector3 caharscale = transform.localScale;
        if (varx < 0)
        {
            caharscale.x = -localscalx;
        }
        if (varx > 0)
        {
            caharscale.x = localscalx;
        }
        transform.localScale = caharscale;


        //scalling and changing faces
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        animationp.Idel();

    } //grounded or not detection

    public void Jumpstate()
    {
        if (grounded == true)
        {
            rb.velocity = new Vector2(0, jumpforce);
            animationp.jump();
            animationp.NotIdel();
            grounded = false;
        }   //jump
        {
            //if (movespeed > 1f)
            //{
            //   speed = 2;
            // }
            //if (movespeed < 1f)
            // {
            //    speed = -1;
            // }
        }//comment windows control
    }

	 public void OnTriggerEnter2D(Collider2D collision)
	 {
			if (collision.gameObject.CompareTag("Coins"))
			{
				 audio.Play();
				 Debug.Log("Sound Sucesssssssssssssssssssssssssssssssssssssssssssssssssssssss");

			}

        if (collision.gameObject.CompareTag("Girl"))
        {
            image.IsActive();
            Debug.Log("Ho raha hai");
        }

	 }

}
