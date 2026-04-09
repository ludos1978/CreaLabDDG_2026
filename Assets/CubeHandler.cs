using UnityEngine;

public class CubeHandler : MonoBehaviour
{

    public float forcePower = 100f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
  {
    GetComponent<Rigidbody>().AddForce(Vector3.up * forcePower);
  }
}
