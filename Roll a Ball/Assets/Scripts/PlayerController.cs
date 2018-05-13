using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//The Game objects RigidyBody component
	private Rigidbody rb;

	//Runs when the scene starts
	void Start() {
		//Gets the rigid body component
		rb = GetComponent<Rigidbody>();
	}

	//Called Before Rendering a frame
	/*void Update() {

	}*/

	//Called just before performing any physics calculations
	void FixedUpdate() {
		//Get the H,V input components
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//Create the force vector
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//Apply the force vector to the game object
		rb.AddForce (movement);
	}

}
