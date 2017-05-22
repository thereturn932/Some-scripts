using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieverCanvas : MonoBehaviour {

    public void TakeItems()
    {

        if (Quest.q1Selected == true)
        {
            for (int i = 0; i < LeaderItemData.leaderData.Count; i++)
            {
                if (Quest.qItem1 == LeaderItemData.leaderData[i].Title)
                {
                    LeaderItemData.leaderData[i].numberOfItems = LeaderItemData.leaderData[i].numberOfItems + Quest.numberOfItems1;
                    GameMasterSc.haveItems = false;
                    Quest.q1Selected = false;
                    print(LeaderItemData.leaderData[i].Title + " : " + LeaderItemData.leaderData[i].numberOfItems.ToString());
                }
            }
        }
        if (Quest.q2Selected == true)
        {
            for (int i = 0; i < LeaderItemData.leaderData.Count; i++)
            {
                if (Quest.qItem2 == LeaderItemData.leaderData[i].Title)
                {
                    LeaderItemData.leaderData[i].numberOfItems = LeaderItemData.leaderData[i].numberOfItems + Quest.numberOfItems2;
                    GameMasterSc.haveItems = false;
                    Quest.q2Selected = false;
                    print(LeaderItemData.leaderData[i].Title + " : " + LeaderItemData.leaderData[i].numberOfItems.ToString());
                }
            }
        }
    }
}
