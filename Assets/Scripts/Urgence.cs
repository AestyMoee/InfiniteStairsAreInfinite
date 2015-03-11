using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Urgence : MonoBehaviour {

    public AudioClip[] audioBlink;
    AudioSource audioSource;
	Light lightEmergency;

	// Use this for initialization
	void Start() {
        audioSource = GetComponent<AudioSource>();
		lightEmergency = GetComponent<Light> ();
		lightEmergency.enabled = true; //On s'assure que la lumière soit bien allumée
		StartCoroutine (LightOff());
	}

    void Update()
    {
        if (!audioSource.isPlaying && lightEmergency.enabled)
        {
            //Si pas de son mais que la lumière est allumée
            audioSource.clip = audioBlink[0];
            audioSource.Play();
        }
    }
	
	IEnumerator LightOn() {
		yield return new WaitForSeconds(Random.Range(0.1f,0.9f));
		lightEmergency.enabled = true;
        audioSource.clip = audioBlink[0];
        audioSource.Play();
		StartCoroutine (LightOff());

	}
	IEnumerator LightOff() {
		yield return new WaitForSeconds(Random.Range(0.1f,0.9f));
		lightEmergency.enabled = false;
        audioSource.clip = audioBlink[1];
        audioSource.Play();
		StartCoroutine (LightOn());
		
	}
}
