using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKontrola : MonoBehaviour {

    public GameObject AUTO;
    public ParticleSystem snijeg;
    // Use this for initialization
    void Start () {
        snijeg.Stop();
	}
	
	// Update is called once per frame
	void Update () {

    }

    // to je za prvu mapu (zeleno) AUTO.transform.position = new Vector3(2.24f, 1.21f, -0.71f);
    // ovo je za pustinju AUTO.transform.position = new Vector3(2.24f, 1.21f, 23.78f);
    // ovo je za snijeg AUTO.transform.position = new Vector3(2.24f, 1.21f, 48,15f);
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Auto" && GLOBALNE.TrenutnaMapa == 1)
        {
            GLOBALNE.TrenutnaMapa = 2;
            snijeg.Stop();
            AUTO.transform.position = new Vector3(2.24f, 2f, -0.71f);
        }
        else if (other.name == "Auto" && GLOBALNE.TrenutnaMapa == 2)
        {
            GLOBALNE.TrenutnaMapa = 3;
            snijeg.Stop();
            AUTO.transform.position = new Vector3(2.24f, 2f, 23.78f);
        }
        else if (other.name == "Auto" && GLOBALNE.TrenutnaMapa == 3)
        {
            GLOBALNE.TrenutnaMapa = 1;
            snijeg.Play();
            AUTO.transform.position = new Vector3(2.24f, 2f, 48.15f);
        }

    }


}
