using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromjenaJezika : MonoBehaviour {

    public Text PlayButton;
    public Text GarageButton;
    public Text ControlsButton;
    public Text AboutButton;
    public Text ExitButton;
    public Text Distance;

    public void HrvatskiJezik()
    {
        GLOBALNE.EngHrv = true;
        PlayButton.text = Croatian.IgrajButtonText;
        GarageButton.text = Croatian.GarazaButtonText;
        ControlsButton.text = Croatian.KontroleButtonText;
        AboutButton.text = Croatian.OIgriButtonText;
        ExitButton.text = Croatian.IzadiIzIgreButtonText;
        Distance.text = Croatian.prijedenokilometara;
    }
    public void EngleskiJezik()
    {
        GLOBALNE.EngHrv = false;
        PlayButton.text = English.PlayButtonText;
        GarageButton.text = English.GarageButtonText;
        ControlsButton.text = English.ControlsButtonText;
        AboutButton.text = English.AboutButtonText;
        ExitButton.text = English.ExitButtonText;
        Distance.text = English.distance;
    }




}
