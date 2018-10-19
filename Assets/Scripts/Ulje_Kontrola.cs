using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulje_Kontrola : MonoBehaviour {

    public GameObject Ulje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Auto")
        {
           GLOBALNE.TrenutnaBrzina = 0.1f;
           GLOBALNE.TrenutnoSkretanje = 0.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Auto")
        {
            GLOBALNE.TrenutnoSkretanje = 0.6f;
        }
    }
}
