using UnityEngine;

public class SpearScript : AbstractWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        offset = 1.3f;
        cooldown = 2;
        weaponDuration = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position = new Vector3(player.transform.position.x + offset, player.transform.position.y, player.transform.position.z);
    }
}
