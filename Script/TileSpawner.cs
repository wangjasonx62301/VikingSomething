using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    public GameObject[] tilePrefabs;

    public Transform playerTransform;
    private float spawnZ = 0.0f;
    private float spawnX = 0.0f;
    private float tileLength = 45.0f;
    private int amountOnScreen = 7;
    private float savePoint = 35f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    public void spawnTiles(int prefabIndex = -1)
    {
        GameObject go;
        int index = randomPrefabIndex();
        go = Instantiate(tilePrefabs[index]) as GameObject;
        go.transform.SetParent(transform);
        // go.transform.position = Vector3.forward * spawnZ;
        if(index == 0)
            go.transform.position = new Vector3(go.transform.position.x + 6f + spawnX, go.transform.position.y - 3.5f, spawnZ - 5f);
        if(index == 1)
            go.transform.position = new Vector3(go.transform.position.x + spawnX, go.transform.position.y - 10.5f, spawnZ);
        if (index == 2)
        {
            go.transform.position = new Vector3(go.transform.position.x + spawnX + 5f, go.transform.position.y - 10f, spawnZ + 10f);
            spawnX += 73f;
        }
        if(index == 3)
            go.transform.position = new Vector3(go.transform.position.x + spawnX, go.transform.position.y - 11f, spawnZ);
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    public void deleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        for(int i = 0; i < amountOnScreen; i++)
        {
            spawnTiles();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - savePoint > (spawnZ - amountOnScreen * tileLength))
        {
            spawnTiles();
            deleteTiles(); 
        }
    }

    private int randomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
