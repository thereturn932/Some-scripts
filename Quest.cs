using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quest : MonoBehaviour {

    public static float timer = 7;
    public static int numberOfItems1 = 7, numberOfItems2 = 10;
    public static string qItem1 = "elma", qItem2 = "odun";
    public static bool q1Selected, q2Selected;
    public static float q1Time = 7, q2Time = 10;
    public  float tm;


    void Start () {
    }


    void Update() {
        tm = timer;
        if (Mover.startQuest == true)
        {
            timer = timer - Time.deltaTime;
        }
        if(timer <= 0 )
        {
            Mover.startQuest = false;
            Mover.isStarting = true;
            QuestScreen.haveQuest = false;
            timer = 1;
            GameMasterSc.haveItems = true;
            
        }
	}


}
