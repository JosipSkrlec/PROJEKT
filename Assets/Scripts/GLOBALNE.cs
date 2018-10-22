using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Globalne Varijable omogucuju komunikaciju izmedu vise skripti.
/// Takoder globalne varijable (Za SAVE) sluze kako bi se postavile neke vrijednosti prilikom ucitavanja igre.
/// </summary>

public class GLOBALNE : MonoBehaviour
{
    // ZA SAVE
    public static float NajvecaBrzinaAuta;
    public static float Ubrzanje;
    public static float Usporavanje;

    public static int TurboTime;
    // scale slika za gorivo
    public static float OduzimanjeScaleSlika;
    public static int OduzimanjeOdSto;
    public static int BrojSvihNovcica;


    // temp u igri
    public static bool NastaviIgrati = true;
    public static bool PrikaziPanelZaNastavakIgreJednom = true;
    public static bool Kupnjagorivajedanput = true;
    
    public static bool UgasiPanelZaNastavakIgre = true;

    public static float TrenutnoSkretanje;
    public static float TrenutnoGorivo;
    public static float TrenutnaBrzina;
    public static float MaxGoriva;
    public static int MaxTurbo = 100;

    public static int GORIVO;
    public static int TURBO;
    public static int BrojNovcicaTrenutno;
    public static int BrojPrijedenihMetara;

    // ne treba refreshati
    // TRUE je HRV false je ENG
    public static bool EngHrv = true;
    public static int UkupanBrojPrijedenihMetara;

    // ovo je za pamcenje koja mapa je trenutno pa da se ne spawna na istoj!
    // mapa 1-2-3 = zeleno-pustinja-snijeg
    public static int TrenutnaMapa = 2;




}



