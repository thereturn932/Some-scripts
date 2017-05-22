using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

    private Animator anim;
    public int ind;
    public bool hq;
    public bool controllerBool;
	
    // Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        hq = false;
	}
	
	// Update is called once per frame
	void Update () {
        controllerBool = Mover.startPoint;
        ind = Mover.currentIndex;
        if (Mover.currentIndex == 1 && hq == false)
        {
            anim.SetBool("isWalking_left", false);
            anim.SetBool("isWalking_right", true);
        }
        if (Mover.currentIndex == 2 && hq == false)
        {
            anim.SetBool("isWalking_down", true);
            anim.SetBool("isWalking_right", false);
        }
        if(Mover.arrived == true)
        {
            anim.SetBool("isWalking_down", false);
            anim.SetBool("Stop", true);
            hq = true;
            Mover.arrived = false;
        }
        if (Mover.currentIndex == 1 && hq == true)
        {
            anim.SetBool("Stop", false);
            anim.SetBool("isWalking_up", true);
        }
        if (Mover.currentIndex == 0 && hq == true)
        {
            anim.SetBool("isWalking_up", false);
            anim.SetBool("isWalking_left", true);
        }
        if (Mover.startPoint == true)
        {
            hq = false;
            Mover.startPoint = false;
        }
           
        


    }
}
