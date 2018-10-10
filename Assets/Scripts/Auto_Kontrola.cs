using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Auto_Kontrola : MonoBehaviour
{
    // TIPS
    // Objekt Auto se ne smije Destroy-ati
    // Auto stane kada je GLOBALNE.GORIVO = 0; a full je GLOBALNE.GORIVO = 110;
    // skretanje auta , normal je 0.6f 
    //

        // TODO - distance counter, napraviti counter distance
    #region Public varijable
    public Text Brzinomjer;
    public Text Odbrojavanje;
    public Text FramesPerSecond;
    public Text PostotakGoriva;
    public RawImage ZelenoGorivoSlika;
    public GameObject PanelZaNastavakIgre;
    #endregion

    #region Ostale Varijable
    // trenutne varijable u koje se stavlja vrijednost iz GLOBALNE
    float MaxBrzina = 0.0f;
    float Ubrzanje = 0.0f;
    float odbrojavanjeVremenaZaGorivo = 0.0f;

    // trenutne ostale varijable
    int provjerabrojacaZaPocetakIgre = 0;

    float odbrojavanjevremenaZaPocetakIgre = 0.0f;

    bool Triggerzagorivojednom = true;

    // ZA FPS
    public float updateRateSeconds = 4.0f;
    int frameCount = 0;
    float dt = 0.0f;
    float fps = 0.0f;

    // Zvuk

    #endregion

    // Use this for initialization
    void Start()
    {
        PanelZaNastavakIgre.SetActive(false);
        // TODO - metoda init koja ce citati iz datoteke byte i pretvarati u vrijednosti i stavljati u globalne varijable
        GLOBALNE.NajvecaBrzinaAuta = 30.0f;
        GLOBALNE.Ubrzanje = 2.0f;
        GLOBALNE.MaxGoriva = 2.0f;
        GLOBALNE.TrenutnoGorivo = GLOBALNE.MaxGoriva;
        GLOBALNE.GORIVO = 100;
        GLOBALNE.TrenutnoSkretanje = 0.6f;

        PostotakGoriva.text = "100 %";

        MaxBrzina = GLOBALNE.NajvecaBrzinaAuta;
        Ubrzanje = GLOBALNE.Ubrzanje;

    }

    // Update is called once per frame
    void Update()
    {
        FPS();

        // provjera brojaca je counter koji odbrojava do 5 sekundi od startup-a jer metoda i kontrole za skretanje se pozivaju u else if kada brojac
        if (provjerabrojacaZaPocetakIgre != 5)
        {
            OdbrojavanjeVremena();
        }
        // ako je GLOBALNE.GORIVO = 0 tada Auto stane!
        else if(GLOBALNE.GORIVO != 0 && GLOBALNE.NastaviIgrati == true)
        {
            // if else za skretanje u lijevo i desno A=lijevo, D=desno
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0.0f, Input.GetAxis("Horizontal") * GLOBALNE.TrenutnoSkretanje, 0.0f, Space.World);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0.0f, Input.GetAxis("Horizontal") * GLOBALNE.TrenutnoSkretanje, 0.0f, Space.World);
            }

            // pretvorba float u int i ispis na ekran brzinu
            int temp = (int)GLOBALNE.TrenutnaBrzina;
            Brzinomjer.text = temp  + " km/h";

            UbrzajAuto();

            odbrojavanjeVremenaZaGorivo += Time.deltaTime;

            //Debug.Log(odbrojavanjeVremena1);
            #region Opis zasto su 2 if-a
            // prvi if je za provjeru vremena, ako prode zadano vrijeme ulazi u if i zove metodu smanji gorivo
            // drugi if je da provjeri da li je broj veci od zadanog vremena, ukoliko je seta trigger u true
            // dok metoda smanjigorivo seta isti trigger u false , jer time.deltatime je u float i pozvao bi metodu
            // vise puta jer se update u 1 sekundi poziva vise puta od jednom!
            #endregion
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

            GLOBALNE.NastaviIgrati = false;
            PanelZaNastavakIgre.SetActive(true);

            // TODO - 2.BACI ZAVRSNI SCREEN S BROJEM COINSA - kontrola sa public static bool PrikaziPanelZaNastavakIgreJednom = true; 






        }


    }

    /// <summary>
    /// Metoda FPS(), prikazuje trenutne framove po sekundi.
    /// </summary>
    void FPS()
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

    /// <summary>
    /// Metoda UbrzajAuto(), Ubrzava Auto u smjeru kordinate Y za vrijednost GLOBALNE.TrenutnaBrzina.
    /// </summary>
    void UbrzajAuto()
    {
        // pomakni auto u smjeru 0,-Y,0.. -y jer je objekt okrenut u tom polozaju
        transform.Translate(0.0f, -GLOBALNE.TrenutnaBrzina * Time.deltaTime, 0.0f);

        GLOBALNE.TrenutnaBrzina += Ubrzanje * Time.deltaTime * 2;

        if (GLOBALNE.TrenutnaBrzina > MaxBrzina)
        {
            GLOBALNE.TrenutnaBrzina = MaxBrzina;
        }
        //Debug.Log("Brzina" + TrenutnaBrzina);
    }

    /// <summary>
    /// Metoda OdbrojavanjeVremena(), broji do 5 te prikazuje u UI Text vrijeme do pocetka igre.
    /// </summary>
    void OdbrojavanjeVremena()
    {
        odbrojavanjevremenaZaPocetakIgre += Time.deltaTime;

        provjerabrojacaZaPocetakIgre = (int)odbrojavanjevremenaZaPocetakIgre;

        if (provjerabrojacaZaPocetakIgre > 1)
        {
            Odbrojavanje.text = "2";
        }
        if (provjerabrojacaZaPocetakIgre > 2)
        {
            Odbrojavanje.text = "1";
        }
        if (provjerabrojacaZaPocetakIgre > 3)
        {
            Odbrojavanje.text = "DRIVE!";
        }
        if (provjerabrojacaZaPocetakIgre > 4)
        {
            provjerabrojacaZaPocetakIgre = 5;
            Odbrojavanje.GetComponent<Text>().enabled = false;
        }

    }

    /// <summary>
    /// Metoda SmanjiGorivo(), skalira sliku ZeleniBar za svakih odbrojavanjeVremenaZaGorivo sekundi (3) za vrijednost GLOBALNE.TrenutnoGorivo (-0.2f).
    /// </summary>
    void SmanjiGorivo()
    {
        //y =0.79768
        //z =1
        if (Triggerzagorivojednom == true)
        {
            // prikaz GorivoSlika ukoliko je false a false je po default-u
            if (ZelenoGorivoSlika.enabled == false)
            {
                ZelenoGorivoSlika.enabled = true;
            }  

            // za scale
            GLOBALNE.TrenutnoGorivo = GLOBALNE.TrenutnoGorivo - 0.2f;

            int temp = 0;
            temp = GLOBALNE.GORIVO - 10;
            GLOBALNE.GORIVO = temp;

            PostotakGoriva.text = temp + " %";


            ZelenoGorivoSlika.transform.localScale = new Vector3(GLOBALNE.TrenutnoGorivo, 0.5f, 1);

            Triggerzagorivojednom = false;

        }

    }



}

