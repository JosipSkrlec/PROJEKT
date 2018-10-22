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

    #region Public varijable
    public Text Brzinomjer;
    public Text Odbrojavanje;
    public Text FramesPerSecond;
    public Text PostotakGoriva;
    public Text PrijedenoMetara;
    public Text prijedenoText;
    public RawImage ZelenoGorivoSlika;
    public RawImage PlaviTurboSlika;
    public GameObject PanelZaNastavakIgre;
    public RawImage FullTurbo;
    public GameObject Svjetla;
    public GameObject DanNocsvjetlo;
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
    float TurboOdbrojavanje;

    bool Triggerzagorivojednom = true;
    bool SvjetlaHelper = true;
    bool TurboHelper = true;
    bool SpacejePritisnut = false;
    bool samojednomTurbo = true;

    // za turbotemp
    int TurboTemp1 = 0;
    float TurboTemp2 = 0.0f;

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
        FullTurbo.enabled = false;
        Svjetla.SetActive(false);

        DanNoc();
        // promjena jezika , true i false se seta na pocetnoj (ulaznoj) sceni
        if (GLOBALNE.EngHrv == true)
        {
            prijedenoText.text = Croatian.prijedenokilometara;
            PrijedenoMetara.text = "0 metara";
        }
        else if (GLOBALNE.EngHrv == false)
        {
            prijedenoText.text = English.prijedenokilometara;
            PrijedenoMetara.text = "0 meters";
        }
        // u init je za upgrade i za Coinse
        INIT();

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
        else if (GLOBALNE.GORIVO != 0 && GLOBALNE.NastaviIgrati == true)
        {
            // if else za skretanje u lijevo i desno A=lijevo, D=desno
            if (GLOBALNE.TrenutnaBrzina > 2 && GLOBALNE.TrenutnaBrzina < 5)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(0.0f, Input.GetAxis("Horizontal") * 0.2f, 0.0f, Space.World);

                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(0.0f, Input.GetAxis("Horizontal") * 0.2f, 0.0f, Space.World);
                }
            }
            else if (GLOBALNE.TrenutnaBrzina > 5)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(0.0f, Input.GetAxis("Horizontal") * GLOBALNE.TrenutnoSkretanje, 0.0f, Space.World);

                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(0.0f, Input.GetAxis("Horizontal") * GLOBALNE.TrenutnoSkretanje, 0.0f, Space.World);
                }
            }


            #region Objasnjenje turba i deaktivacije
            //TurboOdbrojavanje je varijabla koja se svake sekunde podize za deltatime sve dok mi ne pritisnemo space,
            //te ga postavi na 0 i postavi na spacejepritisnut na true
            // nakon sto postavi na 0 mozemo uci i prvi if ispod, space je pritisnut se stavlja na false tako da se unutar if-a pozove samo jednom
            // deaktivacijaTurba() je metoda koja se poziva te sve varijable vraca na prethodno stanje
            #endregion
            TurboOdbrojavanje += Time.deltaTime;

            if (TurboOdbrojavanje < 3 && SpacejePritisnut == true)
            {
                if (samojednomTurbo == true)
                {
                    TurboTemp1 = TrenutnaBrzinaAuta + 15;
                    TurboTemp2 = MaxBrzina + 15;
                    GLOBALNE.TrenutnaBrzina = TurboTemp2;
                }
                Debug.Log("Trenutna brzina: " + GLOBALNE.TrenutnaBrzina);
                Debug.Log("Turbo: " + GLOBALNE.TURBO);

                MaxBrzina = TurboTemp2;
                TrenutnaBrzinaAuta = TurboTemp1;
                Brzinomjer.text = TrenutnaBrzinaAuta * 2 + " km/h";
                UbrzajAuto();

                samojednomTurbo = false;


            }
            else if (TurboOdbrojavanje < 6 && SpacejePritisnut == true)
            {
                SpacejePritisnut = false;
                DekativacijaTurba();
            }

            if (Input.GetKeyDown(KeyCode.Space) && TurboHelper)
            {
                TurboMetodaNaPritisakSpace();
            }

            // Za paliti svjetla
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
            if (Input.GetKey(KeyCode.W) && SpacejePritisnut == false)
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
            else if (!Input.GetKey(KeyCode.W) && SpacejePritisnut == false)
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
    /// Metoda INIT() ucitava iz datoteke podatke te sprema u GLOBALNE varijable
    /// </summary>
    void INIT()
    {
        SAVE.UPGRADES.UcitajTrenutnoStanjeAuta();
        SAVE.COINS.UcitajStanjeCoinsa();

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

    }

    /// <summary>
    /// Funkcija koja mjenja boju na directionlight za dan i noc.. random 
    /// </summary>
    void DanNoc()
    {
        int temp1 = Random.Range(1, 3);
        // NOC
        if (temp1 == 1)
        {
            //Debug.Log("1");
            DanNocsvjetlo.GetComponent<Light>().color = new Color(0, 0, 0, 250);
        }
        // DAN
        if (temp1 == 2)
        {
            //Debug.Log("2");
            DanNocsvjetlo.GetComponent<Light>().color = new Color(1, 1, 1, 1);
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
            if (GLOBALNE.EngHrv == true)
            {
                Odbrojavanje.text = "VOZI!";
            }
            else if (GLOBALNE.EngHrv == false)
            {
                Odbrojavanje.text = "DRIVE!";
            }
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
        tempzabrojmetara += ((brzina * 1000) / 3600) * 2;
        if (GLOBALNE.EngHrv == true)
        {
            PrijedenoMetara.text = tempzabrojmetara + (" metara");
        }
        else if (GLOBALNE.EngHrv == false)
        {
            PrijedenoMetara.text = tempzabrojmetara + (" meters");
        }


        GLOBALNE.BrojPrijedenihMetara = tempzabrojmetara;

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
                FullTurbo.enabled = true;
            }
            else if (GLOBALNE.TURBO < GLOBALNE.MaxTurbo && ScaleSlikaTurbo < 2.0f)
            {
                BrojacSvakihPedestMetara += 50;
                GLOBALNE.TURBO += 10;
                ScaleSlikaTurbo += DodavanjeScaleSlikaTurbo;
                PlaviTurboSlika.transform.localScale = new Vector3(ScaleSlikaTurbo, 0.25f, 1);
            }
            else if (GLOBALNE.TURBO == 100)
            {
                FullTurbo.enabled = true;
            }

        }

    }

    /// <summary>
    /// TurboMetodaNaPritisakSpace() je metoda koja kontrolira varijable koje utjecu na Ubrzanje auta i traje 3 sek
    /// </summary>
    /// <returns></returns>
    void TurboMetodaNaPritisakSpace()
    {
        if (GLOBALNE.TURBO == 100)
        {
            PlaviTurboSlika.transform.localScale = new Vector3(0.01f, 0.25f, 1);
            FullTurbo.enabled = false;
            SpacejePritisnut = true;
            ScaleSlikaTurbo = 0.01f;
            TurboOdbrojavanje = 0;

            GLOBALNE.TURBO = 10;
            TurboHelper = false;
        }

    }

    /// <summary>
    /// DeaktivacijaTurba() je metoda koja ponisti sve i reseta varijable na prethodno stanje
    /// </summary>
    void DekativacijaTurba()
    {
        MaxBrzina -= 15;
        TrenutnaBrzinaAuta -= 15;
        GLOBALNE.TrenutnaBrzina = MaxBrzina;
        TurboHelper = true;

    }


}



