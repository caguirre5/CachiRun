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
    public float[] zPositions = { -1.5f, 0f, 1.5f };
    void Start()
    {
        if (gameStartController.Playing)
        {
            Invoke("InstantiateObject", 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateObject()
    {
        int randomIndex = Random.Range(0, obstacles.Length);

        // Instanciar el objeto en el punto de aparición
        Instantiate(obstacles[randomIndex], transform.position, Quaternion.Euler(0, -90, 0));

        Invoke("InstantiateObject", Random.Range(minInterval, maxInterval));
    }
}
