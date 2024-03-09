using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public float minInterval = 1f; // Intervalo mínimo entre instanciaciones
    public float maxInterval = 3f; // Intervalo máximo entre instanciaciones

    private bool temp = false;
    public MenuController gameStartController;
    // Start is called before the first frame update
    public float[] zPositions = new float[3] { -0.5f, 2.5f, 5.5f };
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateObject()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        // float randomZ = transform.position.z + Random.Range(-3f, 3f);
        float randomZ = zPositions[Random.Range(0, zPositions.Length)];
        Debug.Log("Posicion en z = "+randomZ);

        // Instanciar el objeto en el punto de aparición
        Instantiate(obstacles[randomIndex], new Vector3(transform.position.x, transform.position.y, randomZ), Quaternion.Euler(0, -90, 0));

        Invoke("InstantiateObject", Random.Range(minInterval, maxInterval));
    }

    public void StartComponent()
    {
        Invoke("InstantiateObject", 2f);
    }
}
