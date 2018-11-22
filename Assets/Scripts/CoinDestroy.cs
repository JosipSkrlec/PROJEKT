using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDestroy : MonoBehaviour {

    public GameObject CoinZaDestroy;
    public Text BrojNovcicaPrikaz;

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Auto")
        {
            GLOBALNE.BrojNovcicaTrenutno += 1;
            BrojNovcicaPrikaz.text = GLOBALNE.BrojNovcicaTrenutno.ToString();

            //CoinZaDestroy.GetComponent<MeshRenderer>().enabled = false;

            Destroy(CoinZaDestroy); 
        }
    }    
}
