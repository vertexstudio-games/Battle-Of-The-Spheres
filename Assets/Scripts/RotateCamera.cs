using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 30f;
    private float inputHorizontal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, inputHorizontal * rotationSpeed * Time.deltaTime);
    }
}
