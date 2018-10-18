using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UkupanBrojPrijedenihPrikaz : MonoBehaviour {

    public Text ukupanbrojprijedenih;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SAVE.BROJMETARA.UcitajBrojPrijedenihMetara();
        ukupanbrojprijedenih.text = GLOBALNE.UkupanBrojPrijedenihMetara.ToString();
	}



}
