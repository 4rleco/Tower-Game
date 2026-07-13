using UnityEngine;

[CreateAssetMenu(fileName = "lvlData", menuName = "Scriptable Objects/lvlData")]
public class LvlData : ScriptableObject
{
    [Header("Tower")]
    [SerializeField] public TowerpartLogic towerpartPrefab;
    [field:SerializeField] public float lifes { get; private set; }
    [field:SerializeField] public float perfectScore { get; private set; }
    [field:SerializeField] public float score { get; private set; }
}
