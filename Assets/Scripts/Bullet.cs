using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float bulletSpeed;
	
	// Update is called once per frame
	void Update () {
		//The bullet will always move the direction it is facing, which was
		//	set when we spawned it in the Player class.
		//We move it forward by getting this forward vector(we'll consider the 
		//	character's forward to be to the right of the sprite), then adding it
		//	to the bullet's current position.
		Vector2 forward = transform.right;
		forward.Normalize();
		Vector2 nextPosition = transform.position;
		nextPosition.x += forward.x*bulletSpeed;
		nextPosition.y += forward.y*bulletSpeed;
		//Finally, we assign the position to our next position.
		transform.position = nextPosition;

		//Make sure the bullet is still in the bounds of the game.
		bool inBounds = GameManager.instance.InGameBounds(transform.position);

		//if it isn't, delete it.
		if(!inBounds) {
			Destroy(this.gameObject);
		}
	}

}
