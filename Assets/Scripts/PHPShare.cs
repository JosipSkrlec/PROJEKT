using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHPShare : MonoBehaviour {

    public Button sharebutton;
    public InputField Ime;
    public Text tekst;

    // TODO - ovaj link zamjeniti sa server linkom te napraviti security (session)
    string pocetnilink = "localhost/IGRA/NoviRezultat.php";
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

        glavnilink = pocetnilink + "?ime=" + "\""+ ImeIgraca + "\"" + "&metri=" + "\"" + Prijedenimetri + "\"";

        WWW www = new WWW(glavnilink);

        tekst.text = "Hvala na dijeljenju";

        sharebutton.gameObject.SetActive(false);
        Ime.gameObject.SetActive(false);

    }

}
