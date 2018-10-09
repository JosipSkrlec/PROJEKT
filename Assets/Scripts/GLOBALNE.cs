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

    public static int BrojSvihNovcica;


    // temp u igri
    public static float TrenutnoSkretanje;
    public static float TrenutnoGorivo;
    public static float TrenutnaBrzina;
    public static float MaxGoriva;

    public static int GORIVO;
    public static int BrojNovcicaTrenutno1;



}