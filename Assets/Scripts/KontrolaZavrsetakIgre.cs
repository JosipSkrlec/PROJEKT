using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolaZavrsetakIgre : MonoBehaviour {

    public Text TrenutnoNovcica;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        TrenutnoNovcica.text = GLOBALNE.BrojNovcicaTrenutno.ToString();
    }

}
