using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kretanje : MonoBehaviour {

    public GameObject Auto;
    AudioSource Pjesma;

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


        if (Auto.transform.position.z >=210)
        {
            Auto.transform.position = new Vector3(-40.1f, -16.09f, 5.96f);
        }
        else
        {
        Auto.transform.Translate(0.0f, -1.0f * Time.deltaTime*2, 0.0f);

        }
    }




}
