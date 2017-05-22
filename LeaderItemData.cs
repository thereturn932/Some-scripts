using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderItemData : MonoBehaviour {

    public static List<Item> leaderData = ItemsDatabase.database;

	// Use this for initialization
	void Start () {
        Debug.Log(ItemsDatabase.FecthItemByID(0).Title);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
