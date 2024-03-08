using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollectibleControl : MonoBehaviour
{
    public float ScrollFactor = -1;
    public Vector3 gameVelocity;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * ScrollFactor;
    }

    void OnTriggerExit(Collider gameArea)
    {
        // Destroy(gameObject);
        transform.position += Vector3.right * (gameArea.bounds.size.x + GetComponent<BoxCollider>().size.x);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }

    }

}

