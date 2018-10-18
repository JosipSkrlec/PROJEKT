using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{


    public Text Upgrade1;
    public Text Upgrade2;
    public Text Upgrade3;
    public Text OpisTrenutnogStanja;
    public Button Button1upgrade;
    public Button Button2upgrade;
    public Button button3upgrade;

    float temp1 = 0.0f;
    float temp2 = 0.0f;
    float temp3 = 0.0f;

    private void Start()
    {
        SAVE.UPGRADES.UcitajTrenutnoStanjeAuta();

    }
    private void Update()
    {
        temp1 = GLOBALNE.NajvecaBrzinaAuta;
        temp2 = GLOBALNE.Ubrzanje;
        temp3 = GLOBALNE.Usporavanje;

        OpisTrenutnogStanja.text = "Auto trenutno ide max brzinom od " + GLOBALNE.NajvecaBrzinaAuta * 2
        + ". Auto ubrzava za " + GLOBALNE.Ubrzanje + " m/s " + "te uporava za -" + GLOBALNE.Usporavanje + " m/s";

        // za upgrade1
        if (temp1 == 35.0f)
        {
            Upgrade1.text = "Full upgrade";
            Button1upgrade.enabled = false;
        }
        else if (temp1 == 15.0f)
        {
            Upgrade1.text = "lvl1. 50km/h";
        }
        else if (temp1 == 25.0f)
        {
            Upgrade1.text = "lvl2. 60km/h";
        }
        else if (temp1 == 30.0f)
        {
            Upgrade1.text = "lvl3. 70km/h";
        }
        // za upgrade2
        if (temp2 == 3.0f)
        {
            Upgrade2.text = "Full upgrade";
            Button2upgrade.enabled = false;
        }
        else if (temp2 == 1.0f)
        {
            Upgrade2.text = "lvl1. +2 m/s";
        }
        else if (temp2 == 2.0f)
        {
            Upgrade2.text = "lvl2. +2.5 m/s";
        }
        else if (temp2 == 2.5f)
        {
            Upgrade2.text = "lvl3. +3 m/s";
        }

        // za upgrade3
        if (temp3 == 1.0f)
        {
            Upgrade3.text = "Full Upgrade";
            button3upgrade.enabled = false;
        }
        else if (temp3 == 3.0f)
        {
            Upgrade3.text = "lvl1. -2 m/s";
        }
        else if (temp3 == 2.0f)
        {
            Upgrade3.text = "lvl2. -1.5 m/s";
        }
        else if (temp3 == 1.5f)
        {
            Upgrade3.text = "lvl3. -1 m/s";
        }

    }


    public void Upgrade1Buy()
    {
        if (temp1 == 15.0f)
        {

            GLOBALNE.NajvecaBrzinaAuta = 25.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }
        if (temp1 == 25.0f)
        {

            GLOBALNE.NajvecaBrzinaAuta = 30.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }
        if (temp1 == 30.0f)
        {

            GLOBALNE.NajvecaBrzinaAuta = 35.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }

    }


    public void Upgrade2Buy()
    {
        if (temp2 == 1.0f)
        {

            GLOBALNE.Ubrzanje = 2.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }
        if (temp2 == 2.0f)
        {

            GLOBALNE.Ubrzanje = 2.5f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }
        if (temp2 == 2.5f)
        {

            GLOBALNE.Ubrzanje = 3.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }

    }


    public void Upgrade3Buy()
    {
        if (temp3 == 3.0f)
        {

            GLOBALNE.Usporavanje = 2.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }
        if (temp3 == 2.0f)
        {

            GLOBALNE.Usporavanje = 1.5f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }
        if (temp3 == 1.5f)
        {

            GLOBALNE.Usporavanje = 1.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();
        }

    }



}
