using UnityEngine;
using System.Collections;

public class NoEuclidManager : MonoBehaviour {

    private int compteur = 0;

    private bool icecream1 = false; //iceCream iScream HaHa !!

    void Update()
    {
        if (compteur == 2 && !icecream1)
        {  
            icecream1 = true;
            Light[] allLight = FindObjectsOfType<Light>();

            foreach(Light l in allLight){
                l.enabled = false;
            }
        }
    }

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			other.transform.position = new Vector3(other.transform.position.x,0.86f, other.transform.position.z);
        compteur++;
	}


}
