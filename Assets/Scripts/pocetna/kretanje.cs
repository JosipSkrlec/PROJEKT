using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kretanje : MonoBehaviour {

    public GameObject Auto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Auto.transform.position.z >=210)
        {
            Auto.transform.position = new Vector3(-40.1f, -16.09f, 5.96f);
        }
        else
        {
        Auto.transform.Translate(0.0f, -1.0f * Time.deltaTime, 0.0f);

        }
    }




}
