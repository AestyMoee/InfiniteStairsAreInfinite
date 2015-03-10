using UnityEngine;
using System.Collections;

public class Urgence : MonoBehaviour {

	Light lightEmergency;

	// Use this for initialization
	void Start() {
		lightEmergency = GetComponent<Light> ();
		lightEmergency.enabled = true; //On s'assure que la lumière soit bien allumée
		StartCoroutine (LightOff());
	}
	
	IEnumerator LightOn() {
		yield return new WaitForSeconds(Random.Range(0.1f,0.9f));
		lightEmergency.enabled = true;
		StartCoroutine (LightOff());

	}
	IEnumerator LightOff() {
		yield return new WaitForSeconds(Random.Range(0.1f,0.9f));
		lightEmergency.enabled = false;
		StartCoroutine (LightOn());
		
	}
}
