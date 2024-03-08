using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessScrollHouse : MonoBehaviour
{
    public float ScrollFactor = -1;
    public Vector3 gameVelocity;

    private bool temp = false;
    Rigidbody rb;

    public MenuController menucontroller;
    // Start is called before the first frame update
    void Start()
    {
        if (menucontroller.Playing)
        {

            rb = GetComponent<Rigidbody>();
            rb.velocity = gameVelocity * ScrollFactor;
        }
    }

    void OnTriggerExit(Collider gameArea)
    {
        if (gameArea.CompareTag("SpawnArea"))
        {
            // Realizar acciones específicas si el collider tiene el tag deseado
            // Por ejemplo, destruir el objeto o cambiar su posición
            // Destroy(gameObject);
            transform.position = new Vector3(41.25f, 0.25f, 9.15f);
        }
    }
}
