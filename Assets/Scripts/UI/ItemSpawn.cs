using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{

    public void SpawnItem()
    {
        var ItemName = gameObject.transform.Find("ItemName").GetComponentInChildren<Text>();
        InventoryManager.Instance.SpawnCheck(ItemName);
        Destroy(gameObject);
    }

}
