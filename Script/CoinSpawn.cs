using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Transform Coin;

    List<Transform> coinList;

    // Start is called before the first frame update
    void Start()
    {
        coinList = new List<Transform>();


        for(int i = 0; i < 3; i++)
        {
            Transform t = Instantiate(Coin);
            Transform p = transform.GetChild((int)Random.Range(0, transform.childCount));
            t.name = "coins";
            t.parent = p;
            t.localPosition = Vector3.zero;

            coinList.Add(t);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
