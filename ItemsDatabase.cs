using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemsDatabase : MonoBehaviour {
    public static List<Item> database = new List<Item>();
    private JsonData itemData;

	// Use this for initialization
	void Start ()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();

        // Debug.Log(FecthItemByID(4).Title);
    }
	
    public static Item FecthItemByID(int id)
    {
        for(int i = 0; i < database.Count; i++)
        {   
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for(int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["ID"], itemData[i]["Title"].ToString(),(int)itemData[i]["numberOfItems"]));
        }
    }

}

public class Item
{
    public int ID { get;  set; }
    public string Title { get;  set; }
    public int numberOfItems { get; set; }

    public Item(int id, string title, int numberOfItems)
    {
        this.ID = id;
        this.Title = title;
        this.numberOfItems = numberOfItems;
    }

    public Item()
    {
        this.ID = -1;
    }
}
