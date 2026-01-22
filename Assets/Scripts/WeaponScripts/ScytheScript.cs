using System.Collections;
using UnityEngine;

public class ScytheScript : AbstractWeapon
{
    private void Awake()
    {
        cooldown = 3;
        weaponDuration = 0.2f;
    }


    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x+offset,player.transform.position.y,player.transform.position.z);
    }
}
