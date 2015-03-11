﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof (AudioSource))]

public class CharacterManager : MonoBehaviour {
	private AudioSource audioSource;
	private Light torche;

	public AudioClip[] sndListStep;

	public float speedRun = 6.0F;
	public float speedWalk = 2.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private float timeBetweenStep;

	void Start(){
		audioSource = GetComponent<AudioSource> ();

		torche = GetComponentInChildren<Light> ();
	}

	void Update() {
		moveCharacter ();

		if (Input.GetKeyDown (KeyCode.F)) {
			torche.enabled = !torche.enabled;
			torche.GetComponent<AudioSource>().Play();
		}
	}

	void moveCharacter(){
		float speed;

		if (Input.GetKey (KeyCode.LeftShift))
        {
            speed = speedRun;
            audioSource.volume = 0.3f;
        }
        else
        {
            speed = speedWalk;
            audioSource.volume = 0.1f;
        }

		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			if (moveDirection.magnitude > 0.5f && timeBetweenStep < Time.time) { 
				audioSource.clip = sndListStep [Random.Range (0, sndListStep.Length)];
				audioSource.Play ();

				if(speed == speedWalk)
					timeBetweenStep = Time.time + 0.9f;
				else
					timeBetweenStep = Time.time + 0.3f;

			}
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

}
