using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu
    (
        fileName = "New Location",
        menuName = "ScriptableObjectLocation",
        order = 0
        )
]

public class LocationScriptableObject : ScriptableObject
{
    public string locationName;
    public string locationDesc;

    public LocationScriptableObject north;
    public LocationScriptableObject south;
    public LocationScriptableObject east;
    public LocationScriptableObject west;

    public ItemScriptableObject item;
    
    public void PrintLocation()
    {
        string printStr = "\nLocation Name: " + locationName +
                          "\nLocation Description " + locationDesc;
        
        Debug.Log(printStr);
    }

    public void UpdateCurrentLocation(GameManager gm)
    {
        gm.titleUI.text = locationName;
        gm.descriptionUI.text = locationDesc;

        // North
        if (north == null)
        {
            gm.buttonNorth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonNorth.gameObject.SetActive(true);
            north.south = this;
        }

        // South
        if (south == null)
        {
            gm.buttonSouth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonSouth.gameObject.SetActive(true);
            south.north = this;
        }

        // East
        if (east == null)
        {
            gm.buttonEast.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonEast.gameObject.SetActive(true);
            east.west = this;
        }
        
        // West
        if (west == null)
        {
            gm.buttonWest.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonWest.gameObject.SetActive(true);
            west.east = this;
        }

        // Displaying the item info
        if (item == null)
        {
            Debug.Log("Nothing to pick up here");
            
            gm.pickUpButton.gameObject.SetActive(false);
            gm.itemInfo.text = "";
        }
        else
        {
            Debug.Log(item.itemName);
            
            gm.pickUpButton.gameObject.SetActive(true);
            gm.itemInfo.text = item.itemDesc;
        }
    }
}
