using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Auto_Kontrola : MonoBehaviour {

    #region Public varijable
    public Text Brzinomjer;
    public Text Odbrojavanje;
    #endregion

    #region Ostale Varijable
    private float TrenutnaBrzina = 0.0f;

    float MaxBrzina = 0.0f;
    float Ubrzanje = 0.0f;
    float odbrojavanjevremena = 0.0f;

    int provjerabrojaca = 0;
    #endregion

    // Use this for initialization
    void Start () {

       GLOBALNE.NajvecaBrzinaAuta = 10.0f;
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
        Brzinomjer.text = temp / 2 + " km/h";

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
        odbrojavanjevremena += Time.deltaTime;

        provjerabrojaca = (int)odbrojavanjevremena;

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
            Odbrojavanje.text = "DRIVE!";         
        }
        if (provjerabrojaca > 4)
        {
            provjerabrojaca = 5;
            Odbrojavanje.GetComponent<Text>().enabled = false;
        }
        
    }


}
