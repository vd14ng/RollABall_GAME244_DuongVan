using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{	
	
	// create public variables for player speed, and for the Text UI game objects
	public float speed;
	
	// create list for Inventory
	public List<GameObject> inventory = new List<GameObject>();
	
	// reference ItemInfo script
	private Item itemInfo;
	
	// create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	
	// private int count;
	private GameController gameController;
	private Vector2 moveInput;

	// At the start of the game..
	void Start ()
	{
		gameController = GetComponentInParent<GameController>();
		
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		// count = 0;
	}
	
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
	private void FixedUpdate()
	{
		// Get movement direction from input
		Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
		
		// Add movement force to player (multiplied by speed)
		rb.AddForce(movement * speed);
	}
	
	
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
}