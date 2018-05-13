using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//A reference to the player object
	public GameObject player;
	//The offset between the player and the camera
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame
	//Guaranteed to run after all items have been processed in update
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
