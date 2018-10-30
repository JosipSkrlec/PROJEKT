using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDestroyBad : MonoBehaviour
{

    public GameObject CoinZaDestroy;
    public Text BrojNovcicaPrikaz;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Auto")
        {
            if (GLOBALNE.BrojNovcicaTrenutno >= 3)
            {
                GLOBALNE.BrojNovcicaTrenutno -= 3;
                BrojNovcicaPrikaz.text = GLOBALNE.BrojNovcicaTrenutno.ToString();

                //CoinZaDestroy.GetComponent<MeshRenderer>().enabled = false;

            }
            Destroy(CoinZaDestroy);
        }
    }
}
