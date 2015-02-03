using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	private Animator animStairs, animTrigger;

	public float speedRun = 6.0F;
	public float speedWalk = 2.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		moveCharacter ();
	}

	void moveCharacter(){
		float speed;

		if (Input.GetKey (KeyCode.LeftShift))
			speed = speedWalk;
		else
			speed = speedRun;
		

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

}
