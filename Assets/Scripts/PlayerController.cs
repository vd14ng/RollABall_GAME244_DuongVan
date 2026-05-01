using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{	
	
	// Create public variables for PLAYER SPEED
	// and for the TEXT UI GAME OBJECTS
	public float speed;
	
	// Create list for INVENTORY
	public List<GameObject> inventory = new List<GameObject>();
	
	// Reference ItemInfo class
	private Item itemInfo;
	
	// Create private references to the RigidBody component on the player
	// and the count of objects picked up so far
	private Rigidbody rb;
	
	// Variables to jump
	private bool isGrounded;
	public float jumpForce = 5f;
	
	// private int count;
	private GameController gameController;
	private Vector3 moveInput;
	
	void Start ()
	{
		gameController = GetComponentInParent<GameController>();
		
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
		
		//

		// Set the count to zero 
		// count = 0;
	}

	/* void Update()
	{
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			Jump();
		}
	}

	private void Jump()
	{
		// ForceMode.Impulse is best for jumps as it applies the force instantly
		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		isGrounded = false;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	} */

	public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
	private void FixedUpdate()
	{
		// get movement direction from input
		Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
		
		// add movement force to player (multiplied by speed)
		rb.AddForce(movement * speed);
	}
	
	
	// when this game object intersects a collider with 'is trigger' checked, 
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
		/* string currentItemsInInventory = "";
		foreach (GameObject item in inventory)
		{
			print(item.GetComponent<Item>().itemName);
		} */
	}
	
	private void CollectItem(GameObject item)
	{
		inventory.Add(item);
		
		// UPDATE to see which objects are in the list
		// InventoryStatusUpdate();
		
	}
}