using UnityEngine;

[CreateAssetMenu(fileName = "lvlData", menuName = "Scriptable Objects/lvlData")]
public class LvlData : ScriptableObject
{
    [Header("Tower")]
    [SerializeField] public TowerpartLogic towerpartPrefab;
    [field:SerializeField] public float amountOfParts { get; private set; }
}
