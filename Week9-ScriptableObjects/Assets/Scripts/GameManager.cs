using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI descriptionUI;

    public LocationScriptableObject currenLocation;

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;
    
    // Start is called before the first frame update
    void Start()
    {
        currenLocation.PrintLocation();
        currenLocation.UpdateCurrentLocation(this);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void PickUpItem()
    {
        
    }
}
