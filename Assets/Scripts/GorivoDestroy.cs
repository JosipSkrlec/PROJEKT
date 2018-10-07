using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorivoDestroy : MonoBehaviour {
   
    public GameObject GorivoZaDestroy;
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

            GLOBALNE.TrenutnoGorivo = 1.82f;
            GLOBALNE.GORIVO = 6;
            GorivoSlika.transform.localScale = new Vector3(GLOBALNE.TrenutnoGorivo, 0.79768f, 1);

            Destroy(GorivoZaDestroy);

        }



    }








}
