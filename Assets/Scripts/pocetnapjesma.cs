using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocetnapjesma : MonoBehaviour {

    public static AudioSource Pjesma;

    // Use this for initialization
    void Start () {
        Pjesma = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Pjesma.isPlaying == false)
        {
            Pjesma.Play();
        }
    }
}
