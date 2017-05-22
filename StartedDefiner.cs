using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartedDefiner : MonoBehaviour {

	// Use this for initialization
	void Awake () {

        Mover.isStarting = true;
        Mover.startQuest = false;

        Quest.q1Selected = false;
        Quest.q2Selected = false;

        QuestScreen.haveQuest = false;

        GameMasterSc.haveItems = false;
    }
}
