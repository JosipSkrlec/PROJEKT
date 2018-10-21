using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKontrola : MonoBehaviour {

    public GameObject AUTO;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    // to je za prvu mapu (zeleno) AUTO.transform.position = new Vector3(2.24f, 1.21f, -0.71f);
    // ovo je za pustinju AUTO.transform.position = new Vector3(2.24f, 1.21f, 23.78f);
    // ovo je za snijeg AUTO.transform.position = new Vector3(2.24f, 1.21f, 48,15f);
    private void OnTriggerEnter(Collider other)
    {
        int temp1 = Random.Range(1, 4);

        if (other.name == "Auto" && temp1 == 1 && GLOBALNE.TrenutnaMapa != 1)
        {
            GLOBALNE.TrenutnaMapa = 1;
            AUTO.transform.position = new Vector3(2.24f, 2f, -0.71f);
        }
        else if (other.name == "Auto" && temp1 == 2 && GLOBALNE.TrenutnaMapa != 2)
        {
            GLOBALNE.TrenutnaMapa = 2;
            AUTO.transform.position = new Vector3(2.24f, 2f, 23.78f);
        }
        else if (other.name == "Auto" && temp1 == 3 && GLOBALNE.TrenutnaMapa != 3)
        {
            GLOBALNE.TrenutnaMapa = 3;
            AUTO.transform.position = new Vector3(2.24f, 2f, 48.15f);
        }
        else
        {
            GLOBALNE.TrenutnaMapa = 1;
            AUTO.transform.position = new Vector3(2.24f, 2f, -0.71f);
        }


    }


}
