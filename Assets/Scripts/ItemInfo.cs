using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    // this class stores information
    // about each item in the game.
    
    // you can customize it so it fits
    // your storyline or theme.
    
    public string itemName;
    public int itemCount;
    public bool isCollectable;
    
    // ITEMS for our Inventory list
    // this is purely information for your list
    public Item(string name, int quantity, GameObject other)
    {
        name = itemName;
        quantity = itemCount;
        
        // confirm the object's collectable status
        if (other.gameObject.CompareTag("Collectable"))
        {
            isCollectable = true;
        }
        else
        {
            isCollectable = false;
        }
        
    }
    
}
