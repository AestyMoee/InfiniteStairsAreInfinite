using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpeningScript : MonoBehaviour {

    private Animator animCamera;
    public Animator title;
    public Animator pressToPlay;

	// Use this for initialization
	void Start () {
	    //récupère l'animation et quand elle ne joue plus affiche en fondu les texts
        //Si le joueur appuie sur une touche
        animCamera = GetComponent<Animator>();
        animCamera.Play("AnimCameraOpening");
	}
	
	// Update is called once per frame
	void Update () {

        if (animCamera.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            title.Play("AnimFadeTitle");
            pressToPlay.Play("AnimFadePress");
        }

        if (Input.anyKey)
            Application.LoadLevel("futurScene");
	}
}
