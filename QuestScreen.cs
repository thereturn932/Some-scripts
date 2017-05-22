using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestScreen : MonoBehaviour {

    public float distance;
    public Rigidbody2D hero, questGiver;
    public GameObject qCanvas;
    public Button yourButton;
    public static bool haveQuest;
    public GameObject rCanvas;
    public Text qText1, qText2;

    void Start () {
        qCanvas.SetActive(false);
        rCanvas.SetActive(false);
       // Button btn = yourButton.GetComponent<Button>();
       // btn.onClick.AddListener(SetQuest);
    }
	

	void Update () {
            qText1.text = Quest.numberOfItems1.ToString() + " " + Quest.qItem1 + " getir.";
            qText2.text = Quest.numberOfItems2.ToString() + " " + Quest.qItem2 + " getir.";
        distance = Vector2.Distance(hero.transform.position,questGiver.transform.position);
        if(distance <= 1 && GameMasterSc.haveItems == false)
        {
            qCanvas.SetActive(true);
        } 
        else
        {
            qCanvas.SetActive(false);
        }
        if(distance <= 1 && GameMasterSc.haveItems == true)
        {
            rCanvas.SetActive(true);
        }
        else
        {
            rCanvas.SetActive(false);
        }
	}

    public void SetQuest1()
    {
        Quest.q1Selected = true;
        Mover.arrived = false;
        haveQuest = true;
        Quest.timer = Quest.q1Time;
    }

    public void SetQuest2()
    {
        Mover.arrived = false;
        Quest.q2Selected = true;
        haveQuest = true;
        Quest.timer = Quest.q2Time;
    }

    public void Skip2Night()
    {
        SceneManager.LoadScene("Night");
    }

}
