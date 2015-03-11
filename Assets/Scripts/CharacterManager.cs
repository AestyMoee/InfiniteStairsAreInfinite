using UnityEngine;
using System.Collections;

[RequireComponent(typeof (AudioSource))]

public class CharacterManager : MonoBehaviour {
	private AudioSource[] audioSources;

	public AudioClip[] sndListStep;
    public AudioClip[] sndListAmbient;

	public float speedRun = 6.0F;
	public float speedWalk = 2.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private float timeBetweenStep;

	void Start(){
		audioSources = GetComponents<AudioSource> ();
        StartCoroutine("Bips");
	}

	void Update() {
		MoveCharacter ();
	}

	void MoveCharacter(){
		float speed;

		if (Input.GetKey (KeyCode.LeftShift))
        {
            speed = speedRun;
            audioSources[0].volume = 0.3f;
        }
        else
        {
            speed = speedWalk;
            audioSources[0].volume = 0.1f;
        }

		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			if (moveDirection.magnitude > 0.5f && timeBetweenStep < Time.time) { 
				audioSources[0].clip = sndListStep [Random.Range (0, sndListStep.Length)];
				audioSources[0].Play ();

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

    IEnumerator Bips()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20f, 60f));
            audioSources[2].clip = sndListAmbient[Random.Range(0, sndListAmbient.Length)];
            audioSources[2].Play();
        }

    }

}
