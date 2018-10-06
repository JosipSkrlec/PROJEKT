using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Auto_Kontrola : MonoBehaviour {

    public Text Brzinomjer;
    public Text Odbrojavanje;

    float MaxBrzina = 0.0f;
    private float TrenutnaBrzina = 0.0f;
    float Ubrzanje = 0.0f;
    float temp = 0.0f;
    int provjerabrojaca = 0;



    // Use this for initialization
    void Start () {

       GLOBALNE.NajvecaBrzinaAuta = 100.0f;
       GLOBALNE.Ubrzanje = 4.0f;

       MaxBrzina = GLOBALNE.NajvecaBrzinaAuta;
       Ubrzanje = GLOBALNE.Ubrzanje;

    }
	
	// Update is called once per frame
	void Update () {

        if (provjerabrojaca != 5)
        {
            OdbrojavanjeVremena();
        }
        else
        {

        // if kontrola za skretanje u lijevo
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f, Space.World);
        }
        // if kontrola za skretanje u desno
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f, Space.World);
        }

        // pretvorba float u int i ispis na ekran brzinu
        int temp = (int)TrenutnaBrzina;
        Brzinomjer.text = temp + " km/h";

        Ubrzaj();
        }

    }

    void Ubrzaj()
    {
        // pomakni auto u smjeru 0,-Y,0.. -y jer je objekt okrenut u tom polozaju
        transform.Translate(0.0f, -TrenutnaBrzina * Time.deltaTime, 0.0f);

        TrenutnaBrzina += Ubrzanje * Time.deltaTime * 2;

        if (TrenutnaBrzina > MaxBrzina)
        {
            TrenutnaBrzina = MaxBrzina;
        }
        //Debug.Log("Brzina" + TrenutnaBrzina);
    }

    void OdbrojavanjeVremena()
    {
        temp += Time.deltaTime;

        provjerabrojaca = (int)temp;

        if (provjerabrojaca > 1)
        {
            Odbrojavanje.text = "2";
        }
        if (provjerabrojaca > 2)
        {
            Odbrojavanje.text = "1";
        }
        if (provjerabrojaca > 3)
        {
            Odbrojavanje.text = "GOGO";         
        }
        if (provjerabrojaca > 4)
        {
            provjerabrojaca = 5;
            Odbrojavanje.GetComponent<Text>().enabled = false;
        }
        
    }



}
