using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelikaPrepreka : MonoBehaviour {

    public GameObject Prepreka;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer m = Prepreka.GetComponent<MeshRenderer>();
        m.enabled = false;
        if (GLOBALNE.TrenutnaBrzina < 15)
        {
            GLOBALNE.TrenutnaBrzina = 0;
        }
        else
        {
            GLOBALNE.TrenutnaBrzina -= 15;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MeshRenderer m = Prepreka.GetComponent<MeshRenderer>();
        m.enabled = true;
    }

}
