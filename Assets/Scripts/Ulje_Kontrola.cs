using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulje_Kontrola : MonoBehaviour {

    public GameObject Ulje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Auto")
        {
           float a = GLOBALNE.TrenutnaBrzina;
            GLOBALNE.TrenutnaBrzina = a * 0.50f;
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
