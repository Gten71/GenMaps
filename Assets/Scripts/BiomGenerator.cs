using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BiomGenerator : MonoBehaviour
{
    public GameObject[] biomPrefabs;
    public int mapSizeX;
    public int mapSizeY;
    public float biomSize; // Размер каждого квадрата биома в метрах
    private BiomInfo[,] biomInfoMap;


    private GameObject[,] biomMap;
    


    public void GenerateBiomMap()
    {
        biomInfoMap = new BiomInfo[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                GameObject biomPrefab = biomPrefabs[Random.Range(0, biomPrefabs.Length)];

                Vector3 position = new Vector3(x * biomSize, y * biomSize, 0f);

                // Создаем объект BiomInfo и сохраняем его в массиве biomInfoMap
                BiomInfo biomInfo = new BiomInfo
                {
                    biomPrefab = biomPrefab,
                    position = position
                };

                biomInfoMap[x, y] = biomInfo;
                
                GameObject biomInstance = Instantiate(biomPrefab, position, Quaternion.identity);
                Debug.Log($"Сохранено: Биом {biomPrefab.name} на позиции ({x}, {y})");

            }
        }
    }

}