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
    // STATIC varijable se ne resetiraju na LoadLevel !!

    // TODO -  mora se pozvati funkcija SAVE koja ce spremiti svo trenutno stanje Globalnih varijabli Novcica i upgrade(update,brojnovcica i ostalo!)

    #region Public varijable
    public Text Brzinomjer;
    public Text Odbrojavanje;
    public Text FramesPerSecond;
    public Text PostotakGoriva;
    public Text PrijedenoMetara;
    public RawImage ZelenoGorivoSlika;
    public RawImage PlaviTurboSlika;
    public GameObject PanelZaNastavakIgre;
    public GameObject FullTurbo;
    public GameObject Svjetla;

    #endregion

    #region Ostale Varijable
    // trenutne varijable u koje se stavlja vrijednost iz GLOBALNE
    float MaxBrzina = 0.0f;
    float Ubrzanje = 0.0f;
    float Usporavanje = 0.0f;
    float odbrojavanjeVremenaZaGorivo = 0.0f;
    float odbrojavanjeVremenaZaPrijedeneMetre = 0.0f;

    // trenutne ostale varijable
    int provjerabrojacaZaPocetakIgre = 0;
    int tempzabrojmetara = 0;
    int TrenutnaBrzinaAuta = 0;
    int BrojacSvakihPedestMetara = 50;

    float odbrojavanjevremenaZaPocetakIgre = 0.0f;
    float DodavanjeScaleSlikaTurbo = 0.20f;
    float ScaleSlikaTurbo;

    float ZaSvjetlajedansek;

    bool Triggerzagorivojednom = true;
    bool SvjetlaHelper = true;

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
        FullTurbo.SetActive(false);
        Svjetla.SetActive(false);

        // TODO - metoda init koja ce citati iz datoteke byte i pretvarati u vrijednosti i stavljati u globalne varijable
        GLOBALNE.NajvecaBrzinaAuta = 30.0f;
        GLOBALNE.Ubrzanje = 1.0f;
        GLOBALNE.Usporavanje = 2.0f;
        GLOBALNE.MaxGoriva = 2.0f;
        // sljedece dvije varijable se mjenjaju zajedno.. Za gorivo
        GLOBALNE.OduzimanjeOdSto = 1;
        GLOBALNE.OduzimanjeScaleSlika = 0.02f;

        GLOBALNE.TrenutnoGorivo = GLOBALNE.MaxGoriva;
        GLOBALNE.GORIVO = 100;
        GLOBALNE.TURBO = 10;
        GLOBALNE.NastaviIgrati = true;
        GLOBALNE.TrenutnoSkretanje = 0.6f;
        GLOBALNE.UgasiPanelZaNastavakIgre = true;

        PostotakGoriva.text = "100 %";

        MaxBrzina = GLOBALNE.NajvecaBrzinaAuta;
        Ubrzanje = GLOBALNE.Ubrzanje;
        Usporavanje = GLOBALNE.Usporavanje;

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
            // Za svjetla
            if (Input.GetKey(KeyCode.G))
            {
                ZaSvjetlajedansek += Time.deltaTime;
                if (ZaSvjetlajedansek > 1)
                {

                    if (SvjetlaHelper == true)
                    {
                        Svjetla.SetActive(true);
                        SvjetlaHelper = false;
                    }
                    else if (SvjetlaHelper == false)
                    {
                        Svjetla.SetActive(false);
                        SvjetlaHelper = true;
                    }
                    ZaSvjetlajedansek = 0;
                }

            }

            // pretvorba float u int i ispis na ekran brzinu
            TrenutnaBrzinaAuta = (int)GLOBALNE.TrenutnaBrzina;
            odbrojavanjeVremenaZaPrijedeneMetre += Time.deltaTime;
            // ovaj if je da uzima gorivo i ubrzava auto 
            if (Input.GetKey(KeyCode.W))
            {
                Brzinomjer.text = TrenutnaBrzinaAuta * 2 + " km/h";

                UbrzajAuto();

                odbrojavanjeVremenaZaGorivo += Time.deltaTime;

                if (odbrojavanjeVremenaZaPrijedeneMetre > 1)
                {
                    PrijedeniMetri(TrenutnaBrzinaAuta);
                    ProvjeraZaTurbo();
                    odbrojavanjeVremenaZaPrijedeneMetre = 0;
                }

                //Debug.Log(odbrojavanjeVremena1);
                // TODO - ovaj 0.3f je vrijeme kad oduzme gorivo, treba napraviti globalnu var. koja ce se moci nadograditi da dulje traje vrijeme  npr 0.4f i 0.5f
                #region Opis zasto su 2 if-a
                // prvi if je za provjeru vremena, ako prode zadano vrijeme ulazi u if i zove metodu smanji gorivo
                // drugi if je da provjeri da li je broj veci od zadanog vremena, ukoliko je seta trigger u true
                // dok metoda smanjigorivo seta isti trigger u false , jer time.deltatime je u float i pozvao bi metodu
                // vise puta jer se update u 1 sekundi poziva vise puta od jednom!
                #endregion
                if (odbrojavanjeVremenaZaGorivo > 0.3f)
                {
                    SmanjiGorivo();
                    if (odbrojavanjeVremenaZaGorivo > 0.3f)
                    {
                        odbrojavanjeVremenaZaGorivo = 0;
                        Triggerzagorivojednom = true;
                    }

                }
            }
            // ovaj else je ukoliko je W otpustenmo da usporava auto polagano do 0 i ne uzima gorivo
            else if (!Input.GetKey(KeyCode.W))
            {

                if (odbrojavanjeVremenaZaPrijedeneMetre > 1)
                {
                    PrijedeniMetri(TrenutnaBrzinaAuta);
                    ProvjeraZaTurbo();
                    odbrojavanjeVremenaZaPrijedeneMetre = 0;
                }
                // pretvorba float u int i ispis na ekran brzinu
                int temp = (int)GLOBALNE.TrenutnaBrzina;
                Brzinomjer.text = temp * 2 + " km/h";

                if (GLOBALNE.TrenutnaBrzina > 0)
                {
                    UsporiAuto();
                }

            }
            // TODO - kada je turbo pun, pritiskom na space se ubrza auto na neki odredeni broj sekundi.



        }
        else if (GLOBALNE.GORIVO == 0)
        {
            if (GLOBALNE.UgasiPanelZaNastavakIgre == true)
            {
                PanelZaNastavakIgre.SetActive(true);
            }
            GLOBALNE.NastaviIgrati = false;

                                                  
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
    /// Metoda UsporiAuto() se poziva ukoliko W nije pritisnuto te usporava auto svake sekunde za GLOBALNE.Usporavanje;
    /// </summary>
    void UsporiAuto()
    {
        // pomakni auto u smjeru 0,-Y,0.. -y jer je objekt okrenut u tom polozaju
        transform.Translate(0.0f, -GLOBALNE.TrenutnaBrzina * Time.deltaTime, 0.0f);

        GLOBALNE.TrenutnaBrzina -= Usporavanje * Time.deltaTime * 2;

        if (GLOBALNE.TrenutnaBrzina < 0)
        {
            GLOBALNE.TrenutnaBrzina = 0.0f;
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
            GLOBALNE.TrenutnoGorivo = GLOBALNE.TrenutnoGorivo - GLOBALNE.OduzimanjeScaleSlika;

            int temp = 0;
            temp = GLOBALNE.GORIVO - GLOBALNE.OduzimanjeOdSto;
            GLOBALNE.GORIVO = temp;

            PostotakGoriva.text = temp + " %";


            ZelenoGorivoSlika.transform.localScale = new Vector3(GLOBALNE.TrenutnoGorivo, 0.5f, 1);

            Triggerzagorivojednom = false;

        }

    }

    /// <summary>
    /// Metoda PrijedeniMetri() broji koliko je auto prosao metara
    /// </summary>
    void PrijedeniMetri(int brzina)
    {
        tempzabrojmetara += ((brzina * 1000) / 3600)*2 ;
        PrijedenoMetara.text = tempzabrojmetara + (" metara");

        GLOBALNE.BrojPrijedenihMetara += tempzabrojmetara;

    }
    
    /// <summary>
    /// Metoda ProvjeraZaTurbo() svakih 1 sek provjeri prijedene metre... te za svaku odredenu distancu doda turbo
    /// </summary>
    void ProvjeraZaTurbo()
    {
        if (BrojacSvakihPedestMetara < tempzabrojmetara)
        {

            if (GLOBALNE.TURBO > GLOBALNE.MaxTurbo)
            {
                GLOBALNE.TURBO = 100;
            }
            else if(GLOBALNE.TURBO < GLOBALNE.MaxTurbo && ScaleSlikaTurbo < 2.0f)
            {
                // TODO- ovaj 50 moramo zamijeniti sa Globalnom varijablom koja ce se nadograditi!.. svakih npr. 100 metara 75 doda turbo
                BrojacSvakihPedestMetara += 50;
                GLOBALNE.TURBO += 10;
                ScaleSlikaTurbo += DodavanjeScaleSlikaTurbo;
                PlaviTurboSlika.transform.localScale = new Vector3(ScaleSlikaTurbo, 0.25f, 1);
            }
            else if(GLOBALNE.TURBO == 100)
            {
                FullTurbo.SetActive(true);
            }

        }

    }



}

