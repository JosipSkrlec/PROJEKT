using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorivoDestroy : MonoBehaviour {
   
    public GameObject GorivoZaDestroy;
    public Text PostotakGoriva;
    public RawImage GorivoSlika;

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

            GLOBALNE.TrenutnoGorivo = 2.0f;
            GLOBALNE.GORIVO = 100;
            GorivoSlika.transform.localScale = new Vector3(GLOBALNE.TrenutnoGorivo, 0.5f, 1);

            PostotakGoriva.text = GLOBALNE.GORIVO + " %";

            Destroy(GorivoZaDestroy);
        }
    }
}
