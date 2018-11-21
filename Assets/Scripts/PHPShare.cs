using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHPShare : MonoBehaviour {

    public Button sharebutton;
    public InputField Ime;
    public Text tekst;

    // TODO - ovaj link zamjeniti sa server linkom te napraviti security (session)
    // pocetni link je pomoc kod save data na server. u komentaru denso je link za localhost
    string pocetnilink = "https://turnisce.000webhostapp.com/NoviRezultat.php"; //localhost/IGRA/NoviRezultat.php 
    string glavnilink = " ";

    protected int Prijedenimetri = 0;
    protected string ImeIgraca = " ";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Ime.text.Length == 0)
        {
            sharebutton.gameObject.SetActive(false);
        }
        if(Ime.text.Length >0)
        {
            sharebutton.gameObject.SetActive(true);
        }


	}

    public void PHPShareScore()
    {
        Prijedenimetri = GLOBALNE.BrojPrijedenihMetara;
        ImeIgraca = Ime.text;
        string kodd = "D45800HJOSIP19976HHT0PCF41";
        // http://localhost/IGRA/NoviRezultat.php?ime=Nikola&metri=91

        glavnilink = pocetnilink + "?ime=" + ImeIgraca + "&metri=" + Prijedenimetri+ "&KOD=" + kodd;

        StartCoroutine(WaitForRequest());

        tekst.text = "Hvala Vam :D";

        sharebutton.gameObject.SetActive(false);
        Ime.gameObject.SetActive(false);

    }

    IEnumerator WaitForRequest()
    {
        WWW www = new WWW(glavnilink);
        yield return www;
    }

}
