using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

	int floorMask;
	float camRayLength = 100f;



	public void Start()
	{
		floorMask = LayerMask.GetMask ("Floor");
	}
		
	public void Update ()
	{
       
		//var worldPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 14.0f ));
	
		//if (Input.GetMouseButtonDown (0)) {
			//var go = Instantiate (prefab, worldPoint, Quaternion.identity); // spawngame object at mouse position in world space
			//Vector3 num = go.transform.position - gameObject.transform.forward; // returns vector from two vectors
			//float objToplayer = num.magnitude; // returns distace of vector
			//float playTotarget = objToplayer * (Mathf.Cos (90) * Mathf.Rad2Deg); //get distance from player to target
			//float a = Mathf.Pow (objToplayer, 2) - Mathf.Pow (playTotarget, 2);
			//float objTotarget = Mathf.Sqrt (a); //distance from object to target
		//gameObject.transform.LookAt (new Vector3(worldPoint.x, transform.position.y, worldPoint.z));

		//}

			// Create a ray from the mouse cursor on screen in the direction of the camera.
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			// Create a RaycastHit variable to store information about what was hit by the ray.
			RaycastHit floorHit;

			// Perform the raycast and if it hits something on the floor layer...
			if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
			{
				// Create a vector from the player to the point on the floor the raycast from the mouse hit.
				Vector3 playerToMouse = floorHit.point - transform.position;

				// Ensure the vector is entirely along the floor plane.
				playerToMouse.y = 0f;

				// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
				Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

				// Set the player's rotation to this new rotation.
			GetComponent<Rigidbody>().MoveRotation (newRotation);
			}


	}

}
