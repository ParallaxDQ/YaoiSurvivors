using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player field defs
    [SerializeField] float moveSpeed;
    Rigidbody2D p_rbody;


    //input vars
    float v_mov;
    float h_mov;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p_rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        v_mov = Input.GetAxisRaw("Vertical");
        h_mov = Input.GetAxisRaw("Horizontal");
        p_rbody.linearVelocity = new Vector3(h_mov*moveSpeed,v_mov*moveSpeed);
    }
}
