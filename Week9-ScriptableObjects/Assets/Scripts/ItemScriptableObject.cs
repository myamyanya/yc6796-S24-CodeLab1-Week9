using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu
    (
        fileName = "New Item",
        menuName = "ScriptableObjectItem",
        order = 1
        
    )
]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemDesc;
    public Sprite itemImage;

    public void PrintPickedUpItem()
    {
        string printStr = "\nItem Name: " + itemName +
                          "\nItem Description" + itemDesc;
        
        Debug.Log(printStr);
    }

    public void UpdateItems(GameManager gm)
    {
        if (gm.inventoryItems.Count > 0)
        {
            gm.inventory.text = "You have ..." + "\n" + gm.inventoryItems;
        }
        else
        {
            gm.inventory.text = "Your inventory is empty.";
        }
    }
}
