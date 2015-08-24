using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//class variables:
	//	public variables are visible in the Unity inspector and additional classes
	//	put [HideInInspector] above a public variable if you don't want it to be visible
	//	private variables are hidden.
	public float playerSpeed;
	public int playerHealth;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Here we check for certain player input.
		//	If they press the left arrow, they will rotate around the Z axis.
		//	If they press the right arrow, we rotate them the opposite direction around the Z.
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//Each game object in Unity has a transform. This keeps track of the
			//	position, rotation and scale of that object. The transform has its
			//	own functions that the programmer can use to manipulate it, such as
			//	Rotate(x, y, z).
			transform.Rotate (0, 0, Time.deltaTime*playerSpeed);
			//deltaTime is the speed at which the game is running.
			//We multiply the playerSpeed by deltaTime so that the player will move at
			//	a consistent speed, no matter how fast the game is running.
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (0, 0, -Time.deltaTime*playerSpeed);
		}

		//If the player hits space, we will instantiate(create and place) a bullet prefab.
		if (Input.GetKey (KeyCode.Space)) {
			//Instaniate the bullet at the player's position and rotation
			GameObject.Instantiate(bullet, transform.position, transform.rotation);
		}

	}

	//This function is called by the Unity engine when this object overlaps another.
	void OnCollisionEnter2D(Collision2D collidedWith) {
		if (collidedWith.gameObject.tag == "") {
			playerHealth --;
		}
	}
}
