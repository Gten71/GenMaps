// Скрипт BiomInfo и BiomGenerator работают вместе для генирации биомов 
// Скрипт BiomInfo определяет структуру данных для хранения информации о биомах.
// Он содержит тип биома ( BiomType ) и его позицию в мировых координатах.
// Enum BiomType определяет различные типы биомов, которые могут быть сгенерированы.

using UnityEngine;

[System.Serializable]
public class BiomInfo
{
    public BiomType biomType;
    public Vector3 position;
}
public enum BiomType
{
    FirstBiom,
    SecondBiom,
    ThirdBiom
}
