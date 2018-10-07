using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDestroy : MonoBehaviour {


    public GameObject CoinZaDestroy;
    public Text BrojNovcicaPrikaz;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Auto")
        {
            GLOBALNE.BrojNovcicaTrenutno1 += 1;
            BrojNovcicaPrikaz.text = GLOBALNE.BrojNovcicaTrenutno1.ToString();

            Destroy(CoinZaDestroy);
        }



    }


}
