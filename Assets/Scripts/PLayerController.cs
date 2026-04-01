using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    private float inputVertical;
    private GameObject focalPoint;
    [SerializeField] private GameObject powerupIndicator;

    [SerializeField] private bool hasPowerup;
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

        powerupIndicator.transform.position = transform.position + new Vector3(0f,-0.5f,0f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(focalPoint.transform.forward * inputVertical * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(hasPowerup);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(hasPowerup);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * 15f, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
