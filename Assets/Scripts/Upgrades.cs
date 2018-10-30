using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    // TODO - dodati payment upgrade-ova npr lvl1 = 10c lvl2 = 30c i lvl 3 = 50c
    #region public Varijable
    public Text Upgrade1;
    public Text Upgrade2;
    public Text Upgrade3;
    public Text Upp1;
    public Text Upp2;
    public Text upp3;
    public Text naslov;
    public Text izadi;
    public Text OpisTrenutnogStanja;
    public Button Button1upgrade;
    public Button Button2upgrade;
    public Button button3upgrade;
    #endregion

    #region temp varijable
    float temp1 = 0.0f;
    float temp2 = 0.0f;
    float temp3 = 0.0f;
    int brojNovcica = 0;
    #endregion
    
    private void Start()
    {
        // ucitaj stanje auta i novcica
        SAVE.UPGRADES.UcitajTrenutnoStanjeAuta();
        SAVE.COINS.UcitajStanjeCoinsa();
    }


    private void Update()
    {
        // nakon sto se ucita u startu tada se globalne zapisuju u temp varijable koje kontroliraju upgrade.
        temp1 = GLOBALNE.NajvecaBrzinaAuta;
        temp2 = GLOBALNE.Ubrzanje;
        temp3 = GLOBALNE.Usporavanje;
        brojNovcica = GLOBALNE.BrojSvihNovcica;
        if (GLOBALNE.EngHrv == true)
        {
            OpisTrenutnogStanja.text = "Auto trenutno ide max brzinom od " + GLOBALNE.NajvecaBrzinaAuta * 2
            + ". Auto ubrzava za " + GLOBALNE.Ubrzanje + " m/s " + "te uporava za -" + GLOBALNE.Usporavanje + " m/s";

            Upp1.text = "S ovom nadogradnjom dobit cete vecu dostiznu brzinu auta.";
            Upp2.text = "S ovom nadogradnjom dobit cete brze ubrzavanje automobila.";
            upp3.text = "S ovom nadogradnjomdobit cete sporije padanje brzine priliko otpustanja W tipke.";

            naslov.text = "Garaža";
            izadi.text = "Izađi";
        }
        if (GLOBALNE.EngHrv == false)
        {
            OpisTrenutnogStanja.text = "Car driving with max speed of  " + GLOBALNE.NajvecaBrzinaAuta * 2
            + ". Auto accelerating with " + GLOBALNE.Ubrzanje + " m/s " + "and slow down with -" + GLOBALNE.Usporavanje + " m/s";

            Upp1.text = "With tzhis upgrade your car will have bigger max speed.";
            Upp2.text = "With this upgrade your car will have better acceleration.";
            upp3.text = "With this upgrade speed of car will go down slower.";

            naslov.text = "Garage";
            izadi.text = "Exit";
        }


        // za upgrade1 maxbrzina
        if (temp1 == 35.0f)
        {
            Upgrade1.text = "Full upgrade";
            Button1upgrade.enabled = false;
        }
        else if (temp1 == 15.0f)
        {
            Upgrade1.text = "lvl1. 50km/h           5 Coinsa";
        }
        else if (temp1 == 25.0f)
        {
            Upgrade1.text = "lvl2. 60km/h      20 Coinsa";
        }
        else if (temp1 == 30.0f)
        {
            Upgrade1.text = "lvl3. 70km/h      50 Coinsa";
        }
        // za upgrade2 ubrzanje
        if (temp2 == 3.0f)
        {
            Upgrade2.text = "Full upgrade";
            Button2upgrade.enabled = false;
        }
        else if (temp2 == 1.0f)
        {
            Upgrade2.text = "lvl1. +2 m/s            5 Coinsa";
        }
        else if (temp2 == 2.0f)
        {
            Upgrade2.text = "lvl2. +2.5 m/s       20 Coinsa";
        }
        else if (temp2 == 2.5f)
        {
            Upgrade2.text = "lvl3. +3 m/s       50 Coinsa";
        }

        // za upgrade3 usporavanje
        if (temp3 == 1.0f)
        {
            Upgrade3.text = "Full Upgrade";
            button3upgrade.enabled = false;
        }
        else if (temp3 == 3.0f)
        {
            Upgrade3.text = "lvl1. -2 m/s            5 Coinsa";
        }
        else if (temp3 == 2.0f)
        {
            Upgrade3.text = "lvl2. -1.5 m/s       20 Coinsa";
        }
        else if (temp3 == 1.5f)
        {
            Upgrade3.text = "lvl3. -1 m/s       50 Coinsa";
        }

    }


    public void Upgrade1Buy()
    {
        if (temp1 == 15.0f && brojNovcica >= 5)
        {

            GLOBALNE.NajvecaBrzinaAuta = 25.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 5;
            SAVE.COINS.SpremiStanjeCoinsa();
        }
        if (temp1 == 25.0f && brojNovcica >= 20)
        {

            GLOBALNE.NajvecaBrzinaAuta = 30.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 20;
            SAVE.COINS.SpremiStanjeCoinsa();
        }
        if (temp1 == 30.0f && brojNovcica >= 50)
        {

            GLOBALNE.NajvecaBrzinaAuta = 35.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 50;
            SAVE.COINS.SpremiStanjeCoinsa();
        }

    }


    public void Upgrade2Buy()
    {
        if (temp2 == 1.0f && brojNovcica >= 5)
        {

            GLOBALNE.Ubrzanje = 2.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 5;
            SAVE.COINS.SpremiStanjeCoinsa();
        }
        if (temp2 == 2.0f && brojNovcica >= 20)
        {

            GLOBALNE.Ubrzanje = 2.5f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 20;
            SAVE.COINS.SpremiStanjeCoinsa();
        }
        if (temp2 == 2.5f && brojNovcica >= 50)
        {

            GLOBALNE.Ubrzanje = 3.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 50;
            SAVE.COINS.SpremiStanjeCoinsa();
        }

    }


    public void Upgrade3Buy()
    {
        if (temp3 == 3.0f && brojNovcica >= 5)
        {

            GLOBALNE.Usporavanje = 2.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 5;
            SAVE.COINS.SpremiStanjeCoinsa();
        }
        if (temp3 == 2.0f && brojNovcica >= 20)
        {

            GLOBALNE.Usporavanje = 1.5f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 20;
            SAVE.COINS.SpremiStanjeCoinsa();
        }
        if (temp3 == 1.5f && brojNovcica >= 50)
        {

            GLOBALNE.Usporavanje = 1.0f;
            SAVE.UPGRADES.SpremiTrenutnoStanjeAuta();

            GLOBALNE.BrojSvihNovcica -= 50;
            SAVE.COINS.SpremiStanjeCoinsa();
        }

    }



}
