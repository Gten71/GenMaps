using UnityEngine;

public class BiomGenerator : MonoBehaviour
{
    public GameObject[] biomPrefabs;
    public int mapSizeX;
    public int mapSizeY;
    public float biomSize; // Размер каждого квадрата биома в метрах

    private GameObject[,] biomMap;
    

    private void GenerateBiomMap()
    {
        biomMap = new GameObject[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                GameObject biomPrefab = biomPrefabs[Random.Range(0, biomPrefabs.Length)];
                
                Vector3 position = new Vector3(x * biomSize, y * biomSize, 0f);
                
                GameObject biomInstance = Instantiate(biomPrefab, position, Quaternion.identity);
                
                biomMap[x, y] = biomInstance;
            }
        }
    }
}