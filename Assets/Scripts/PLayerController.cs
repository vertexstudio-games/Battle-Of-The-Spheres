using UnityEngine;

public class PLayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    private float inputVertical;
    private GameObject focalPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(focalPoint.transform.forward * inputVertical * speed);
    }
}
