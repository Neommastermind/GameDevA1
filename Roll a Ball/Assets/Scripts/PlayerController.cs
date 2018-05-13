using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	//The speed of the ball
	public float speed;
	//The text for the count variable
	public Text countText;
	//The win text
	public Text winText;
	//The notification text
	public Text notification;
	//A reference to the players rigid body component
	private Rigidbody rb;
	//The score count
	private int count;

	//Runs on the first frame that the script is active
	void Start() {
		//Gets the rigid body component
		rb = GetComponent<Rigidbody>();
		//Initilize the players count and count text
		count = 0;
		SetCountText ();
		//Initilize the other text objects
		winText.text = "";
		notification.text = "";
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
		rb.AddForce (movement * speed);
	}

	//Defining how a trigger collision with the player works
	void OnTriggerEnter(Collider other) {
		//Check to see if the player hit a pick up object
		if (other.gameObject.CompareTag ("Pick Up")) {
			//deactivate the pick ups upon collision, and increment the count
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		} else if (other.gameObject.CompareTag ("Pick Up Speed")) {
			//Speed up the player
			other.gameObject.SetActive (false);
			speed = 15;
			notification.text = "Your speed has increased!";
		} else if (other.gameObject.CompareTag ("Pick Up Slow")) {
			//Slow down the player
			other.gameObject.SetActive (false);
			speed = 5;
			notification.text = "Your speed has decreased!";
		} else if (other.gameObject.CompareTag ("Pick Up Grow")) {
			//Grow the player
			other.gameObject.SetActive (false);
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			notification.text = "Your size has increased!";
		} else if (other.gameObject.CompareTag ("Pick Up Shrink")) {
			//Shrink the player
			other.gameObject.SetActive (false);
			transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			notification.text = "Your size has decreased!";
		}
	}

	//A function to set the count text and detect if the game has been won
	void SetCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 14) {
			winText.text = "You Win!";
		}
	}
}
