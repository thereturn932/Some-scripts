using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {

    public Text _elmaText, _soyulmusText, _odunText, _kalasText;

	// Use this for initialization
	void Start () {

	}
	    
	// Update is called once per frame
	void Update () {
        _elmaText.text = "Elma : " + LeaderItemData.leaderData[0].numberOfItems.ToString();
        _soyulmusText.text = "Soyulmus Elma : " + LeaderItemData.leaderData[2].numberOfItems.ToString();
        _odunText.text = "Odun : " + LeaderItemData.leaderData[1].numberOfItems;
        _kalasText.text = "Kalas : " + LeaderItemData.leaderData[3].numberOfItems;
	}

    public void ElmalarıSoy()
    {
        if (LeaderItemData.leaderData[0].numberOfItems >= 3)
        {
            LeaderItemData.leaderData[0].numberOfItems = LeaderItemData.leaderData[0].numberOfItems - 3;
            LeaderItemData.leaderData[2].numberOfItems = LeaderItemData.leaderData[2].numberOfItems + 3;
        }
    }

    public void OdunlariIsle()
    {
        if(LeaderItemData.leaderData[1].numberOfItems >= 5)
        {
            LeaderItemData.leaderData[1].numberOfItems = LeaderItemData.leaderData[1].numberOfItems - 5;
            LeaderItemData.leaderData[3].numberOfItems = LeaderItemData.leaderData[3].numberOfItems + 5;
        }
    }
}
