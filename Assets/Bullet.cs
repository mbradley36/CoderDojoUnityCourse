using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//The bullet will always move the direction it is facing, which was
		//	set when we spawned it in the Player class.
		//We move it forward by getting this forward vector(we'll consider the 
		//	character's forward to be to the right of the sprite), then adding it
		//	to the bullet's current position.
		Vector2 forward = transform.right;
		Vector2 nextPosition = transform.position;
		nextPosition.x += forward.x;
		nextPosition.y += forward.y;
		//Finally, we assign the position to our next position.
		transform.position = nextPosition;
	}

}
