using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
	// store a public reference to the PLAYER GAME OBJECT
	// so we can refer to it's transform
	public GameObject player;

	// store a Vector3 offset from the PLAYER
	// (a distance to place the camera from the player at all times)
	private Vector3 offset;

	// start of the game
	void Start ()
	{
		// create an offset by subtracting the Camera's position from the player's position
		offset = transform.position - player.transform.position;
	}

	// after the standard 'Update()' loop runs,
	// and just before each frame is rendered:
	void LateUpdate ()
	{
		// set the position of the CAMERA (the game object this script is attached to)
		// to the player's position, plus the offset amount
		transform.position = player.transform.position + offset;
	}
} 