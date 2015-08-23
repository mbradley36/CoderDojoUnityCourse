using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	//class variables:
	//	public variables are visible in the Unity inspector and additional classes
	//	put [HideInInspector] above a public variable if you don't want it to be visible
	//	private variables are hidden.
	public int health;
	public float obstacleSpeed;
	public bool randomSpeed;

	private Vector2 directionVector;

	// Use this for initialization
	void Start () {
		//set the speed and direction of our obstacle
		if (randomSpeed) {
			SetRandomSpeed ();
		}

		SetRandomDirectionVector ();
	}
	
	// Update is called once per frame
	void Update () {
		//To move the obstacle, we first get it's current position from the transform.
		Vector2 nextPosition = transform.position;
		//Then, we add the direction vector to that position.
		nextPosition.x += directionVector.x;
		nextPosition.y += directionVector.y;
		//Finally, we assign the position to the next position we have created.
		transform.position = nextPosition;
	}

	//This function is called by the Unity engine when this object overlaps another.
	void OnCollisionEnter2D(Collider2D collidedWith) {
		//Objects can be tagged in the Unity Inspector so that they can
		//	easily be checked in code. Here, we have tagged bullets with
		//	a bullet tag so that any time an obstacle runs in to one, we
		//	can check and efficiently know that the bullet is what we ran
		//	in to.
		if (collidedWith.tag == "Bullet") {
			//Destroy the bullet the obstacle collided with.
			GameObject.Destroy(collidedWith);
			//Lower health if it overlapped a bullet.
			DecreaseHealth();
		}
	}

	//This function will randomly choose a speed for the obstacle.
	void SetRandomSpeed() {
		//Random.range is a pre-existing function that will pick a number somewhere between
		//	the numbers we give it. The function may also pick the lower or upper bound we
		//	give it. This is called beign inclusive.
		obstacleSpeed = Random.Range (10, 100);
	}

	//This function determines the direction the obstacle will move across the screen.
	//	This direction is called a vector.
	void SetRandomDirectionVector() {
		//We first need to initialize the vector.
		directionVector = new Vector2();
		//Then, we set the x and y to be randomly determined within our screen space.
		//directionVector.x = Random.Range ();
		//directionVector.y = Random.Range ();
	}

	//function that will check if the object dies when health decreases
	void DecreaseHealth() {
		health --;
		if (health == 0) {
			//if the object is out of health, remove it from the game
			GameObject.Destroy(this);
		}
	}

}
