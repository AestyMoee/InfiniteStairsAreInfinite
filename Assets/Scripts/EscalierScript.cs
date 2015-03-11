﻿using UnityEngine;
using System.Collections;

public class EscalierScript : MonoBehaviour {

    private Animator animatedStairs;

	void Start () {
        animatedStairs = GetComponentInParent<Animator>();
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("test");
            animatedStairs.Play("AnimEscalier");
        }
    }
}
 