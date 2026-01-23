using UnityEngine;
<<<<<<< Updated upstream
=======
using System.Collections;
>>>>>>> Stashed changes

public class PlayerController : MonoBehaviour
{
    //player field defs
    [SerializeField] float moveSpeed;
    Rigidbody2D p_rbody;
<<<<<<< Updated upstream

=======
    bool m_facingRight;
    [SerializeField] GameObject[] weapons;
>>>>>>> Stashed changes

    //input vars
    float v_mov;
    float h_mov;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p_rbody = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
    }

    // Update is called once per frame
    void Update()
    {
        v_mov = Input.GetAxisRaw("Vertical");
        h_mov = Input.GetAxisRaw("Horizontal");
        p_rbody.linearVelocity = new Vector3(h_mov*moveSpeed,v_mov*moveSpeed);
=======
        m_facingRight = true;
        StartAllWeapons();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v_mov = Input.GetAxisRaw("Vertical");
        h_mov = Input.GetAxisRaw("Horizontal");
        FlipCheck();
        p_rbody.linearVelocity = Vector3.Normalize(new Vector3(h_mov,v_mov)) * moveSpeed * Time.deltaTime;
    }

    void Flip()
    {
        float temp = transform.localScale.x;
        temp *= -1;
        transform.localScale =new Vector3(temp, transform.localScale.y, transform.localScale.z);
        m_facingRight = !m_facingRight;
        for (int i = 0; i < weapons.Length; i++)
        {
           AbstractWeapon weaponScript = weapons[i].GetComponent<AbstractWeapon>();
           weaponScript.offset *= -1;
        }
        //weapon1.transform.localScale = new Vector3(temp, weapon1.transform.localScale.y, weapon1.transform.localScale.z);
        print("Flipped");
        
    }

    void FlipCheck()
    {
        if (h_mov < 0 && m_facingRight)
        {
            Flip();
        }
        else if (h_mov>0&&!m_facingRight)
        {
            Flip();
        }
    }



    IEnumerator WeaponCooldown(GameObject weapon) //will break everything called on a non-weapon
    {
        AbstractWeapon weaponScript = weapon.GetComponent<AbstractWeapon>();
        while (true)
        {
            weapon.SetActive(false);
            yield return new WaitForSeconds(weaponScript.cooldown); //replace with unique weapon cooldown
            weapon.SetActive(true);
            yield return new WaitForSeconds(weaponScript.weaponDuration); //replace with unique weapon duration
        }
    }

    void StartAllWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            StartCoroutine(WeaponCooldown(weapons[i]));
        }
>>>>>>> Stashed changes
    }
}
