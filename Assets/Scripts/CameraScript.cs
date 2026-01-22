using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position+new Vector3(0,0,-5);
    }
}
