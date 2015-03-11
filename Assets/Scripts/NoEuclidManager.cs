using UnityEngine;
using System.Collections;

public class NoEuclidManager : MonoBehaviour {

    private int compteur = 0; //On peut rajouter des effets à chaque tour
    private Light[] allLight;
    private bool icecream1 = false; //iceCream iScream HaHa !! //On prévoit le coup pour rajouter d'autres trucs ;)

    void Start()
    {
        allLight = FindObjectsOfType<Light>();
    }

    void Update()
    {
        if (compteur == 2 && !icecream1)
        {  
            icecream1 = true;
            
            foreach(Light l in allLight){
                l.enabled = false;
            }

            audio.Play();
            StartCoroutine("LightOn");
            
        }
    }

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			other.transform.position = new Vector3(other.transform.position.x,0.86f, other.transform.position.z);
        compteur++;
	}


    IEnumerator LightOn()
    {
        yield return new WaitForSeconds(2.0f);
        foreach (Light l in allLight)
        {
            l.enabled = true;
        }
    }

}
