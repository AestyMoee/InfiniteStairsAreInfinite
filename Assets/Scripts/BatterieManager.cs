using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BatterieManager : MonoBehaviour {

    public float dureeLumiere = 10f;
    private Slider batterie;
    private Light torche;
    private float step = 0.1f;
    private float time;
    public Image fill;

	// Use this for initialization
	void Start () {
        batterie = GameObject.Find("BatterieSlider").GetComponent<Slider>();
        batterie.maxValue = dureeLumiere;
        batterie.value = batterie.maxValue;
        torche = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            torche.enabled = !torche.enabled;
            torche.GetComponent<AudioSource>().Play();
            if(torche.enabled)
                time = Time.time + step;
            else
                time = Time.time + 3*step;
        }

        if (Time.time > time)
        {
            if (torche.enabled)
            {
                batterie.value -= step; //Tous les dizièmes de secondes on enlève un dizième à la batterie
                time = Time.time + step;
            }
            else
            {
                batterie.value += step;
                time = Time.time + 3 * step;
            }
        }

        if (batterie.value < dureeLumiere/4)
            fill.color = Color.red;
        else
            fill.color = Color.white;

        if (batterie.value == 0)
            torche.enabled = false;
	}
}
