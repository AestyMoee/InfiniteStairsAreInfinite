using UnityEngine;
using System.Collections;

public class NoEuclidManager : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			other.transform.position = new Vector3(other.transform.position.x,other.transform.position.y-3, other.transform.position.z);
	}
}
