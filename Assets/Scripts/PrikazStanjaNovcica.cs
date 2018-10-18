using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrikazStanjaNovcica : MonoBehaviour
{

    public Text StanjeSvihNovcica;
    // Use this for initialization
    void Start()
    {
        SAVE.COINS.UcitajStanjeCoinsa();
        StanjeSvihNovcica.text = GLOBALNE.BrojSvihNovcica.ToString();
    }



}
