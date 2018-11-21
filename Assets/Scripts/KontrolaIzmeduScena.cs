using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaIzmeduScena : MonoBehaviour {

    public GameObject Panel;
    // Use this for initialization
    public void PokreniScenu(string name)
    {
        ResetirajStaticVarijable();
        Application.LoadLevel(name);
    }

    // Update is called once per frame
    public void UgasiIgru()
    {
        Application.Quit();
    }

    public void PrikaziLeaderBoard()
    {
        Application.OpenURL("http://turnisce.000webhostapp.com");
    }

    public void  ZavrsniPanelShow()
    {
        Panel.SetActive(true);
    }

    public void ZavrsniPanelHide()
    {
        Panel.SetActive(false);
    }

    /// <summary>
    /// Metoda za reset mora biti jer static varijable kod load-anja scene se ne resetiraju !!
    /// </summary>
    void ResetirajStaticVarijable()
    {
        GLOBALNE.NajvecaBrzinaAuta = 0.0f;
        GLOBALNE.Ubrzanje = 0.0f;
        GLOBALNE.Usporavanje = 0.0f;
        GLOBALNE.OduzimanjeScaleSlika = 0.0f;

        GLOBALNE.OduzimanjeOdSto = 0;

        // temp u igri
        GLOBALNE.NastaviIgrati = true;
        GLOBALNE.PrikaziPanelZaNastavakIgreJednom = true;
        GLOBALNE.Kupnjagorivajedanput = true;

        GLOBALNE.UgasiPanelZaNastavakIgre = true;

        GLOBALNE.TrenutnoSkretanje = 0.0f;
        GLOBALNE.TrenutnoGorivo = 0.0f;
        GLOBALNE.TrenutnaBrzina = 0.0f;
        GLOBALNE.MaxGoriva = 0.0f;

        GLOBALNE.GORIVO = 0;
        GLOBALNE.TURBO = 0;
        GLOBALNE.BrojNovcicaTrenutno = 0;
        GLOBALNE.BrojPrijedenihMetara = 0;
        GLOBALNE.TrenutnaMapa = 2;
}



}
