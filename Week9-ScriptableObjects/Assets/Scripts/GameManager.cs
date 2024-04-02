using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // For navigation
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI descriptionUI;

    public LocationScriptableObject currenLocation;

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;
    
    // For pick up items
    public TextMeshProUGUI inventory;

    public TextMeshProUGUI itemInfo;
    public Button pickUpButton;
    
    public ItemScriptableObject pickUpItem;
    
    // Start is called before the first frame update
    void Start()
    {
        currenLocation.PrintLocation();
        currenLocation.UpdateCurrentLocation(this);
        
        //pickUpItem.UpdateItems(this);
    }

    public void MoveDirection(string dirChar)
    {
        switch (dirChar)
        {
            case "N":
                currenLocation = currenLocation.north;
                break;
            case "S":
                currenLocation = currenLocation.south;
                break;
            case "E":
                currenLocation = currenLocation.east;
                break;
            case "W":
                currenLocation = currenLocation.west;
                break;
            default:
                Debug.Log("No way to goooooo!!");
                break;
        }
        
        // ... some confusion about this part
        currenLocation.UpdateCurrentLocation(this);
    }

    public List<string> inventoryItems = new List<string>();
    
    public void PickUp()
    {
        Debug.Log("Collecting...");
        
        inventoryItems.Add(currenLocation.item.itemName + ".");
        currenLocation.item = null;
    }

    private void Update()
    {
        if (inventoryItems.Count > 0)
        {
            string items = string.Join(" ", inventoryItems);
            
            inventory.text = "You have ..." + "\n" + items;
        }
        else
        {
            inventory.text = "Your inventory is empty.";
        }
    }
}
