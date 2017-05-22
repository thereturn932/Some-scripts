using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour {

    public float dayLength = 120;
    public Text timeText;
    public int reputation;
    public GameObject hero;
    public float rnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeText.text = ((int)(dayLength)).ToString();
        if (dayLength > 0)
        {
            dayLength = dayLength - Time.deltaTime;
        }
        if(dayLength < 0)
        {
            SceneManager.LoadScene("Night");
        }

        rnd = Random.Range(0,(10000/reputation)+1);
        if (rnd == 1)
        {
            Instantiate(hero, new Vector2(-8.19f, 2.97f), Quaternion.identity);
        }
	}
}
