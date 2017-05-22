using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour {

    public float moveSpeed = 5;
    public float horizontalMovementTime, verticalMovementTime;
    private Rigidbody2D myHero;


    // Use this for initialization
    void Start () {
        myHero = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        #region input
        /*	if(Input.GetKey(KeyCode.W))
            {
                transform.Translate (new Vector3(0f , moveSpeed * Time.deltaTime, 0f));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0f, 0f));
            }*/
        #endregion
        #region scriptedMovement
        if(horizontalMovementTime > 0)
        {
            myHero.velocity = new Vector2(moveSpeed * Time.deltaTime, 0f);
            horizontalMovementTime = horizontalMovementTime - Time.deltaTime;
        }

        if(horizontalMovementTime <= 0)
        {
            if (verticalMovementTime > 0)
            {
                myHero.velocity = new Vector2(0f, -moveSpeed * Time.deltaTime);
                verticalMovementTime = verticalMovementTime - Time.deltaTime;
            }
            if(verticalMovementTime <= 0)
            {
                myHero.velocity = new Vector2(0f, 0f);
            }
        }
        
        #endregion
    }
}
