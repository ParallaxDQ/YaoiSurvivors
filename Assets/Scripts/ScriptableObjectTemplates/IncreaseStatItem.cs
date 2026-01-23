using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseStatItem", menuName = "Scriptable Objects/IncreaseStatItem")]
public class IncreaseStatItem : ScriptableObject
{
    public Sprite itemSprite;
    public float statIncrease;
    string itemType = "Passive"; //if item type is passive run passiveItemFunc
    public stats statToBeIncreased;
    public float ma_affection;
    public float j_affection;
    public float p_affection;

    public enum stats
    {
        Damage,
        DamagePerc,
        MoveSpeed,
        Defense
    }
}
