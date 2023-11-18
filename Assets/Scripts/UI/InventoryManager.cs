using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item> ();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
          foreach (var item in Items)
          {
              GameObject obj = Instantiate(InventoryItem, ItemContent);
              var itemName = obj.transform.Find("ItemName").GetComponentInChildren<Text>();
              var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
              Debug.Log("adding");
              itemName.text = item.itemName;
              itemIcon.sprite = item.icon;
          }
    }

    public void SpawnCheck(Text Citem)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            if (Citem.text == Items[i].name)
            {
                Vector3 Position = new Vector3(-2.15f, 1.0f, 0.7f);
                Quaternion Rotation = new Quaternion(0, 0, 0, 1);
                var SpawnItem = Items[i];
                this.Remove(Items[i]);
                Debug.Log("Del");
                //DestroyImmediate(Items[i], true);
                Instantiate(SpawnItem.ItemPrefab, Position, Rotation);
            }
        }
    }

}
