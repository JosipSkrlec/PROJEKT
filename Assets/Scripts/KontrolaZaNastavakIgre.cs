using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolaZaNastavakIgre : MonoBehaviour {

    // button opcije za nastavak igre (payment)
    public Button PrvaOpcijaPedesetPostoGoriva;
    public Button DrugaOpcijastoPostoGoriva;
    // ovo je cijeli panel u kojem su smjesteni UI elementi
    public GameObject PanelZaNastavakIgre;
    //public RawImage ZelenoGorivoSlika;
    public RawImage ZelenoGorivoSlika;
    // Text u kojem pise postotak goriva 50 ili 100% nakon kupovine
    public Text PostotakGoriva;
    // Text u kojem se prikazuju broj trenutnih novcica
    public Text BrojNovcicaPrikaz;

    // ovo je scale od zelene slike
    protected const float PrvaOpcija =1.0f;
    protected const float DrugaOpcija = 2.0f;

    public void PedesetPosto()
    {
        if (GLOBALNE.BrojNovcicaTrenutno == 0)
        {
            PrvaOpcijaPedesetPostoGoriva.enabled = false;
        }
        else
        {            
            GLOBALNE.BrojNovcicaTrenutno -= 1;
            BrojNovcicaPrikaz.text = GLOBALNE.BrojNovcicaTrenutno.ToString();
            GLOBALNE.GORIVO = 50;
            GLOBALNE.TrenutnoGorivo = PrvaOpcija;
            GLOBALNE.NastaviIgrati = true;
            GLOBALNE.PrikaziPanelZaNastavakIgreJednom = false;
            PostotakGoriva.text = "50%";

            ZelenoGorivoSlika.transform.localScale = new Vector3(GLOBALNE.TrenutnoGorivo, 0.5f, 1);

            PanelZaNastavakIgre.SetActive(false);
        }

    }

    public void StoPosto()
    {
        if (GLOBALNE.BrojNovcicaTrenutno < 5)
        {
            DrugaOpcijastoPostoGoriva.enabled = false;
        }
        else
        {
            GLOBALNE.BrojNovcicaTrenutno -= 5;
            BrojNovcicaPrikaz.text = GLOBALNE.BrojNovcicaTrenutno.ToString();
            GLOBALNE.GORIVO = 100;
            GLOBALNE.TrenutnoGorivo = DrugaOpcija;
            GLOBALNE.NastaviIgrati = true;
            GLOBALNE.PrikaziPanelZaNastavakIgreJednom = false;
            PostotakGoriva.text = "100%";

            ZelenoGorivoSlika.transform.localScale = new Vector3(GLOBALNE.TrenutnoGorivo, 0.5f, 1);

            PanelZaNastavakIgre.SetActive(false);
        }


    }


    // TODO - napraviti metodu EXIT koja sa panela baca na panel koji prikazuje trenutne coins-e osvojene na mapi
    // U metodi Exit mora se pozvati funkcija SAVE koja ce spremiti svo trenutno stanje (update,brojnovcica i ostalo!)







}
