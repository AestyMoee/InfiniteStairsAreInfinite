using UnityEngine;
using System.Collections;

public class SteamScript : MonoBehaviour {

    public GameObject steam;

    void OnTriggerEnter(Collider other)
    {
        steam.SetActive(true);
    }
}
