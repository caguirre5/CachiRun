using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 gravity;
    public Vector3 jumpSpeed;

    bool isGrounded = false;

    Rigidbody rb;
    Vector3 newPosition;

    float zPosition = 2.5f; // Variable para almacenar la posición Z actual
    float targetZPosition = 2.5f; // Variable para almacenar la posición Z objetivo

    public float movementSpeed = 5f; // Velocidad de movimiento

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            targetZPosition += 3f; // Sumar 1 al valor de la posición Z objetivo
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            targetZPosition -= 3f; // Restar 1 al valor de la posición Z objetivo
        }
        targetZPosition = Mathf.Clamp(targetZPosition, -0.5f, 5.5f);
        zPosition = Mathf.Lerp(zPosition, targetZPosition, Time.deltaTime * movementSpeed);

        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
