using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BiomGenerator : MonoBehaviour
{
    public GameObject[] biomPrefabs;
    public int mapSizeX;
    public int mapSizeY;
    public float biomSize; // The size of each square of the biome

    public BiomInfo[,] biomInfoMap; // public to access from other classes

    private GameObject[,] biomMap;
    private static BiomGenerator instance;

    private void Awake()
    {
        instance = this;
    }

    public static void GenerateBiomMap()
    {
        if (instance == null)
        {
            Debug.LogError("BiomGenerator instance is not set!");
            return;
        }
        

        instance.GenerateMap();
    }

    private void GenerateMap()
    {
        biomInfoMap = new BiomInfo[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                GameObject biomPrefab = GetRandomBiomPrefab(); // create separate method

                Vector3 position = new Vector3(x * biomSize, y * biomSize, 0f);

                // Create BiomInfo and save to biomInfoMap
                BiomInfo biomInfo = new BiomInfo
                {
                    biomPrefab = biomPrefab,
                    position = position
                };

                biomInfoMap[x, y] = biomInfo;

                // Create object
                GameObject biomInstance = Instantiate(biomPrefab, position, Quaternion.identity);
                
                Debug.Log($"Saved: {biomPrefab.name} to position ({x}, {y})");
            }
        }
    }
    private GameObject GetRandomBiomPrefab()
    {
        if (biomPrefabs.Length == 0)
        {
            Debug.LogError("No biomPrefabs assigned!");
            return null;
        }

        return biomPrefabs[Random.Range(0, biomPrefabs.Length)];
    }
}