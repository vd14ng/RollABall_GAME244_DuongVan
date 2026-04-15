Level Design 1 - 3D Project
Chapman University
GAME 244-01
Prof. Prate

This is the README for the INVENTORY MECHANIC for the ROLL-A-BALL Game.

This package contains:
- A new class called 'ItemInfo'
- Changes to classes 'PlayerController' and 'GameController'
- New prefabs for collectable items 'ItemCollectable' and 'Non-ItemCollectable'

In the 'PlayerController' class:
// When this game object intersects a collider with 'is trigger' checked, 
// store a reference to that collider in a variable named 'other'
	
	public void OnTriggerEnter(Collider other) 
	{
		// and if the game object we intersect has the tag 'Collectable' assigned to it..
		if (other.gameObject.CompareTag ("Collectable"))
		{
			// ADD to the Inventory and DISABLE the collectable object
			CollectItem(other.gameObject);
			
			// DISABLE the collected object
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			// count = count + 1;
			// Run the GameController function for picking up a collectible
			// gameController.OnPickUpCollectible(count);
		}
	}

	
	private void InventoryStatusUpdate()
	{
		// string currentItemsInInventory = "";
		foreach (GameObject item in inventory)
		{
			print(item.GetComponent<Item>().itemName);
		}
	}
	
	private void CollectItem(GameObject item)
	{
		inventory.Add(item);
		
		// UPDATE to see which objects are in the list
		InventoryStatusUpdate();
		
	}


In the 'GameController' class:
- Comment out the method 'OnPickUpCollectible'

Last Update: 4/13/2026