using UnityEngine;

abstract public class AbstractWeapon : MonoBehaviour
{
    public GameObject player;
    public float offset = 1;
    public float cooldown;
    public float weaponDuration;
    public bool active;
} //incredibly unsafe, too many public variables.
