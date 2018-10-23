using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject Coin;
    // TODO - popraviti da respawna pobrani coin
    int check1 = 0;
    int check2 = 0;

    void Start()
    {
        SpawnCoin();
    }

    void FixedUpdate()
    {

    }

    void SpawnCoin()
    {

        Vector3 RandomPozicija;
        // stvori na poziciji Random od -1 do 1 , y je 0 zbog visine (uvjek na istoj visini)
        RandomPozicija = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
        // kroz cijeli prostor
        RandomPozicija = transform.TransformPoint(RandomPozicija * .5f);
        //spawn coina
        Instantiate(Coin, RandomPozicija, transform.rotation);    
    }
    private void OnTriggerEnter(Collider other)
    {
        check1 = GLOBALNE.BrojNovcicaTrenutno;

    }

    private void OnTriggerExit(Collider other)
    {
        check2 = GLOBALNE.BrojNovcicaTrenutno;
        if (check1 != check2)
        {
            SpawnCoin();
        }
    }



}
