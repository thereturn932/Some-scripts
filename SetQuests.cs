using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetQuests : MonoBehaviour {

   // public Toggle selectOdun;
   // public Toggle selectElma;
    public Toggle selectQ1, selectQ2;
    public InputField nmbForItems, itemID;
    private int ItemIndex;

	public void ActiveToggle()
    {
        ItemIndex = ItemsDatabase.FecthItemByID(int.Parse(itemID.text)).ID;
        if (selectQ1.isOn)
        {
            Quest.qItem1 = ItemsDatabase.database[ItemIndex].Title;
            Quest.numberOfItems1 = int.Parse(nmbForItems.text);
            Quest.q1Time = int.Parse(nmbForItems.text);
        }
        if (selectQ2.isOn)
        {
            Quest.qItem2 = ItemsDatabase.database[ItemIndex].Title;
            Quest.numberOfItems2 = int.Parse(nmbForItems.text);
            Quest.q2Time = int.Parse(nmbForItems.text);
        }
    }
    public void SelectQuest()
    {
        ActiveToggle();
        Debug.Log("Q1 item : " + Quest.qItem1 + " number : " + Quest.numberOfItems1 + " time : " + Quest.q1Time);
        Debug.Log("Q2 item : " + Quest.qItem2 + " number : " + Quest.numberOfItems2 + " time : " + Quest.q2Time);
    }
}
