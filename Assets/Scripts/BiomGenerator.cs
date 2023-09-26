// Скрипт BiomGenerator отвечает за генерацию карты биомов и создание соответствующих игровых объектов.
// Статический метод GenerateBiomMap вызывается для начала процесса генерации карты биомов.
// Он проверяет, что у нас есть экземпляр класса BiomGenerator и вызывает GenerateMap для создания карты биомов.
// Метод GenerateMap создает карту биомов, выбирая случайный тип биома для каждой клетки карты
// и создавая соответствующий игровой объект. Он также сохраняет информацию о биомах в biomInfoMap.
// Метод GetRandomBiomType выбирает случайный тип биома из Enum BiomType в BiomInfo.
// Метод GetPrefabFromBiomType используется для получения соответствующего префаба игрового объекта на основе типа биома.

using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BiomGenerator : MonoBehaviour
{
    public GameObject[] biomPrefabs;
    public int mapSizeX;
    public int mapSizeY;
    public float biomSize;

    public BiomInfo[,] biomInfoMap; 

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
            Debug.LogError("BiomGenerator instance is not set!" );
            return;
        }
        

        instance.GenerateMap();
    }

    private void GenerateMap()
    {
        biomInfoMap = new BiomInfo[mapSizeX, mapSizeY];

        for ( int x = 0; x < mapSizeX; x++ )
        {
            for ( int y = 0; y < mapSizeY; y++ )
            {
                BiomType biomType = GetRandomBiomType();

                Vector3 position = new Vector3( x * biomSize, y * biomSize, 0f );
                
                BiomInfo biomInfo = new BiomInfo
                {
                    biomType = biomType,
                    position = position
                };

                biomInfoMap[x, y] = biomInfo;
                
                GameObject biomInstance = Instantiate( GetPrefabFromBiomType(biomType), position, Quaternion.identity );
            
                Debug.Log($"Сохранено: {biomType} на позиции ({x}, {y})");
            }
        }
    }
    
    private BiomType GetRandomBiomType()
    {
        Array biomTypes = Enum.GetValues(typeof(BiomType));
        return (BiomType)biomTypes.GetValue(Random.Range(0, biomTypes.Length));
    }

      private GameObject GetPrefabFromBiomType(BiomType biomType)
    {
        switch (biomType)
        {
            case BiomType.FirstBiom:
                return biomPrefabs[0];
            case BiomType.SecondBiom:
                return biomPrefabs[1];
            case BiomType.ThirdBiom:
                return biomPrefabs[2];
            default:
                Debug.LogError( "Неизвестный тип биома: " + biomType );
                return null;
        }
    }
}