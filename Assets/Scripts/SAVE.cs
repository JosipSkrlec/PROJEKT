using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SAVE : MonoBehaviour
{

    public class UPGRADES
    {
        /// <summary>
        /// Metoda SpremiTrenutnoStanje() ukoliko file path ne postoji sprema default vrijednost auta, ukoliko postoji zapise nove vrijednosti koje mjenjaju upgrade-i u GARAGE.
        /// </summary>
        public static void SpremiTrenutnoStanjeAuta()
        {
            string destination = Application.persistentDataPath + "/UPGRADESAUTO.dat";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);
                UPGRADEAutaKlasaZaObjekte a = new UPGRADEAutaKlasaZaObjekte();
                a.Najvecamogucabrzina = GLOBALNE.NajvecaBrzinaAuta;
                a.UbrzavanjeAuta = GLOBALNE.Ubrzanje;
                a.UsporavanjeAuta = GLOBALNE.Usporavanje;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, a);
            }
            else
            {
                file = File.Create(destination);
                UPGRADEAutaKlasaZaObjekte a1 = new UPGRADEAutaKlasaZaObjekte();
                a1.Najvecamogucabrzina = 15.0f;
                a1.UbrzavanjeAuta = 1.0f;
                a1.UsporavanjeAuta = 3.0f;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, a1);
            }

            file.Close();
        }

        /// <summary>
        /// Metoda UcitajTrenutnoStanje() ucita iz datoteke trenutno stanje te ih zapise u varijable GLOBALNE....
        /// </summary>
        public static void UcitajTrenutnoStanjeAuta()
        {
            try
            {

                string destination = Application.persistentDataPath + "/UPGRADESAUTO.dat";
                FileStream file;

                if (File.Exists(destination))
                {
                    file = File.OpenRead(destination);

                    BinaryFormatter bf = new BinaryFormatter();
                    UPGRADEAutaKlasaZaObjekte UcitaniPodaci = (UPGRADEAutaKlasaZaObjekte)bf.Deserialize(file);
                    Debug.Log(destination);

                    GLOBALNE.NajvecaBrzinaAuta = UcitaniPodaci.Najvecamogucabrzina;
                    GLOBALNE.Ubrzanje = UcitaniPodaci.UbrzavanjeAuta;
                    GLOBALNE.Usporavanje = UcitaniPodaci.UsporavanjeAuta;


                }
                else
                {
                    Debug.Log("Problem kod load-a UPGRADE, ili nije spremljeno ili se ucitava prvi puta!");
                    GLOBALNE.NajvecaBrzinaAuta = 15.0f;
                    GLOBALNE.Ubrzanje = 1.0f;
                    GLOBALNE.Usporavanje = 3.0f;

                    return;
                }


                file.Close();

            }
            catch (Exception e)
            {
                Debug.Log("Problem kod load-a UPGRADE, ili nije spremljeno ili se ucitava prvi puta!" + e.Message);
                GLOBALNE.NajvecaBrzinaAuta = 15.0f;
                GLOBALNE.Ubrzanje = 1.0f;
                GLOBALNE.Usporavanje = 3.0f;
            }
        }
    }

    public class COINS
    {
        /// <summary>
        /// Metoda SpremiTrenutnoStanje() ukoliko file path ne postoji sprema default vrijednost auta, ukoliko postoji zapise nove vrijednosti koje mjenjaju upgrade-i u GARAGE.
        /// </summary>
        public static void SpremiStanjeCoinsa()
        {
            string destination = Application.persistentDataPath + "/COINS.dat";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);
                CoinKlasaZaObjekte c = new CoinKlasaZaObjekte();
                GLOBALNE.BrojSvihNovcica += GLOBALNE.BrojNovcicaTrenutno;
                c.COIN = GLOBALNE.BrojSvihNovcica;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, c);
            }
            else
            {
                file = File.Create(destination);
                CoinKlasaZaObjekte c1 = new CoinKlasaZaObjekte();
                c1.COIN = 0;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, c1);
            }

            file.Close();
        }

        /// <summary>
        /// Metoda UcitajStanjeCoinsa() ucita iz datoteke broj skupljenih cins-a
        /// </summary>
        public static void UcitajStanjeCoinsa()
        {
            try
            {

                string destination = Application.persistentDataPath + "/COINS.dat";
                FileStream file;

                if (File.Exists(destination))
                {
                    file = File.OpenRead(destination);

                    BinaryFormatter bf = new BinaryFormatter();
                    CoinKlasaZaObjekte UcitaniPodaci = (CoinKlasaZaObjekte)bf.Deserialize(file);
                    Debug.Log(destination);

                    GLOBALNE.BrojSvihNovcica = UcitaniPodaci.COIN;


                }
                else
                {
                    Debug.Log("Problem kod load-a COINSA, ili nije spremljeno ili se ucitava prvi puta!");
                    GLOBALNE.BrojSvihNovcica = 0;

                    return;
                }


                file.Close();

            }
            catch (Exception e)
            {
                Debug.Log("Problem kod load-a UPGRADE, ili nije spremljeno ili se ucitava prvi puta!" + e.Message);
                GLOBALNE.NajvecaBrzinaAuta = 15.0f;
                GLOBALNE.Ubrzanje = 1.0f;
                GLOBALNE.Usporavanje = 3.0f;
            }
        }

    }



    public class BROJMETARA
    {
        /// <summary>
        /// Metoda SpremiTrenutnoStanje() ukoliko file path ne postoji sprema default vrijednost auta, ukoliko postoji zapise nove vrijednosti koje mjenjaju upgrade-i u GARAGE.
        /// </summary>
        public static void SpremiBrojPrijedenihMetara()
        {
            string destination = Application.persistentDataPath + "/BROJMETARA.dat";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);
                MetarKlasaZaObjekte m = new MetarKlasaZaObjekte();
                GLOBALNE.UkupanBrojPrijedenihMetara += GLOBALNE.BrojPrijedenihMetara;
                m.METRI = GLOBALNE.UkupanBrojPrijedenihMetara;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, m);
            }
            else
            {
                file = File.Create(destination);
                MetarKlasaZaObjekte m = new MetarKlasaZaObjekte();
                GLOBALNE.UkupanBrojPrijedenihMetara += GLOBALNE.BrojPrijedenihMetara;
                m.METRI = GLOBALNE.UkupanBrojPrijedenihMetara;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, m);
            }

            file.Close();
        }

        /// <summary>
        /// Metoda UcitajStanjeCoinsa() ucita iz datoteke broj skupljenih cins-a
        /// </summary>
        public static void UcitajBrojPrijedenihMetara()
        {
            try
            {

                string destination = Application.persistentDataPath + "/BROJMETARA.dat";
                FileStream file;

                if (File.Exists(destination))
                {
                    file = File.OpenRead(destination);

                    BinaryFormatter bf = new BinaryFormatter();
                    MetarKlasaZaObjekte m = (MetarKlasaZaObjekte)bf.Deserialize(file);

                    GLOBALNE.UkupanBrojPrijedenihMetara = m.METRI;

                }
                else
                {
                    Debug.Log("Problem kod load-a BrojaMetara, ili nije spremljeno ili se ucitava prvi puta!");

                    return;
                }


                file.Close();

            }
            catch (Exception e)
            {
                Debug.Log("Problem kod load-a BrojaMetara, ili nije spremljeno ili se ucitava prvi puta!" +e.Message);
            }

        }

    }

    // klasa pomocu koje stvaramo objekte u koje zapisujemo trenutno stanje auta
    [Serializable]
    public class UPGRADEAutaKlasaZaObjekte
    {

        public float Najvecamogucabrzina;
        public float UbrzavanjeAuta;
        public float UsporavanjeAuta;

    }
    // klasa pomocu koje stvaramo objekte COIN
    [Serializable]
    public class CoinKlasaZaObjekte
    {
        public int COIN;

    }
    [Serializable]
    public class MetarKlasaZaObjekte
    {
        public int METRI;
    }



}

