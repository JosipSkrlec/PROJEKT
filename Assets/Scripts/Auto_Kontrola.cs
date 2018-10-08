using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Auto_Kontrola : MonoBehaviour
{
    // TIPS
    // Auto stane kada je GLOBALNE.GORIVO = 0; a full je GLOBALNE.GORIVO = 110;


    #region Public varijable
    public Text Brzinomjer;
    public Text Odbrojavanje;
    public Text FramesPerSecond;
    public Text PostotakGoriva;
    public RawImage GorivoSlika;
    #endregion

    #region Ostale Varijable
    private float TrenutnaBrzina = 0.0f;

    float MaxBrzina = 0.0f;
    float Ubrzanje = 0.0f;
    float odbrojavanjevremena = 0.0f;
    float odbrojavanjeVremenaZaGorivo = 0.0f;


    int provjerabrojaca = 0;

    bool Triggerzagorivojednom = true;

    // ZA FPS
    public float updateRateSeconds = 4.0f;
    int frameCount = 0;
    float dt = 0.0f;
    float fps = 0.0f;
    #endregion

    // Use this for initialization
    void Start()
    {

        GLOBALNE.NajvecaBrzinaAuta = 30.0f;
        GLOBALNE.Ubrzanje = 4.0f;
        GLOBALNE.MaxGoriva = 2.0f;
        GLOBALNE.GORIVO = 100;
        GLOBALNE.TrenutnoGorivo = GLOBALNE.MaxGoriva;

        PostotakGoriva.text = "100 %";

        MaxBrzina = GLOBALNE.NajvecaBrzinaAuta;
        Ubrzanje = GLOBALNE.Ubrzanje;

    }

    // Update is called once per frame
    void Update()
    {
        Fps();
        if (provjerabrojaca != 5)
        {
            OdbrojavanjeVremena();

        }
        else if(GLOBALNE.GORIVO != 0)
        {

            // if kontrola za skretanje u lijevo
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0.0f, Input.GetAxis("Horizontal") * 1.5f, 0.0f, Space.World);
            }
            // if kontrola za skretanje u desno
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0.0f, Input.GetAxis("Horizontal") * 1.5f, 0.0f, Space.World);
            }

            // pretvorba float u int i ispis na ekran brzinu
            int temp = (int)TrenutnaBrzina;
            Brzinomjer.text = temp  + " km/h";

            Ubrzaj();

            odbrojavanjeVremenaZaGorivo += Time.deltaTime;

            //Debug.Log(odbrojavanjeVremena1);

            if (odbrojavanjeVremenaZaGorivo > 3 )
            {
                SmanjiGorivo();
                if (odbrojavanjeVremenaZaGorivo > 3)
                {
                    odbrojavanjeVremenaZaGorivo = 1;
                    Triggerzagorivojednom = true;
                }

            }

        }
        else if (GLOBALNE.GORIVO == 0)
        {
            // TODO
            // BACI ZAVRSNI SCREEN S BROJEM COINSA
        }
    }

    void Fps()
    {
        frameCount++;
        dt += Time.unscaledDeltaTime;
        if (dt > 1.0 / updateRateSeconds)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1.0F / updateRateSeconds;
            
        }
        FramesPerSecond.text = "Fps/" + System.Math.Round(fps, 1).ToString("0");
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

    void SmanjiGorivo()
    {
        //y =0.79768
        //z =1
        if (Triggerzagorivojednom == true)
        {
            if (GorivoSlika.enabled == false)
            {
                GorivoSlika.enabled = true;
            }  


            GLOBALNE.TrenutnoGorivo = GLOBALNE.TrenutnoGorivo - 0.2f;


            int temp = 0;
            temp = GLOBALNE.GORIVO - 10;
            GLOBALNE.GORIVO = temp;

            PostotakGoriva.text = temp + " %";
         

            GorivoSlika.transform.localScale = new Vector3(GLOBALNE.TrenutnoGorivo, 0.5f, 1);

            Triggerzagorivojednom = false;

        }

    }







}

