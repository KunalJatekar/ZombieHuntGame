using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Animationp : MonoBehaviour {

    Animator animator;
    RuntimeAnimatorController startController;
    AnimatorOverrideController animRifleOverride;
    public AnimatorOverrideController animGunOverride;

    public Button firebutton;
    public Button Jumpbutton;
    public Button Swapbutton;

    public bool switchWeapon;
    public bool dead = false;
    public TextAsset boughtWeapon;

    Movement movement;

	void Start ()
    {
        animator = GetComponent<Animator>();
        startController = animator.runtimeAnimatorController ;
        animRifleOverride = new AnimatorOverrideController(startController);
        animRifleOverride = new AnimatorOverrideController(animGunOverride);

        {
            Weapon CurrentWeapon = JsonConvert.DeserializeObject<Weapon>(boughtWeapon.text); //This line is used to deserialize the object of weapon and store it in the CurrentWeapon
            animGunOverride = Resources.Load<AnimatorOverrideController>(CurrentWeapon.weaponController);//This line is used to use resources from resource folder & CurrentWeapon.weaponController call the value of json folder
        }

        //Json file code

        movement = GetComponent<Movement>();  
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            WeaponSwitch();
        }

    }

    public void Run()
    {
            animator.SetFloat("Run", 2f);
    }

    public void Fire()
    {
        animator.SetBool("Fire", true);
        Debug.Log("Fire Sucess");
    }

    public void Notfire()
    {
        animator.SetBool("Fire", false);
    }

    public void jump()
    {
        animator.SetTrigger("Jump");
       // animator.SetFloat("Run", 2f);
    }

    public void NotRun()
    {
        animator.SetFloat("Run", -1f);
    }

    public void Idel()
    {
        animator.SetBool("Grounded", true);
    }

    public void NotIdel()
    {
        animator.SetBool("Grounded", false);
    }

    public void Deadth()
    {
        animator.SetBool("Dead", true);
        firebutton.interactable = false;
        Swapbutton.interactable = false;
        Jumpbutton.interactable = false;
       
        dead = true;

    }
    public void NotDeadth()
    {
        animator.SetBool("Dead", false);
        dead = false;
    }

    public void SetAnimatorOverride(AnimatorOverrideController weaponOverrideController)
    {
        animator.runtimeAnimatorController = weaponOverrideController;
        //cont["RefileIdel"] = cont["Idel"];
    }


    public void WeaponSwitch()
    {
        switchWeapon = !switchWeapon;
        if (switchWeapon)
        {
            SetAnimatorOverride(animGunOverride);
        }
        else
        {
            SetAnimatorOverride(animRifleOverride);
        }
    }

}
