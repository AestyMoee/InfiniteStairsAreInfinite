using UnityEngine;
using System.Collections;

public class ScreamerScript : MonoBehaviour {

    public GameObject screamer;

    private bool wasActived = false; //on désactive quand même le script, on est pas des salô

	// Use this for initialization
	void Update () {

        if (!screamer.audio.isPlaying && wasActived)
        {
            screamer.SetActive(false);
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (!wasActived)
        {
            screamer.SetActive(true);
            wasActived = true;
        }
    }
}
