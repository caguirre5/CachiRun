using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Playing = false;

    public GameObject camera;
    // Posición y rotación final a la que se moverá el objeto
    public Vector3 posicionFinal = new Vector3(0f, 7.12f, -9.08f);
    public Vector3 rotacionFinal = new Vector3(20f, 0f, 0f);

    // Tiempo total que tomará el movimiento (en segundos)
    public float duracionMovimiento = 5f;

    // Tiempo transcurrido desde el inicio del movimiento
    private float tiempoTranscurrido = 0f;

    public Canvas hud;
    public Canvas menu;


    public BarraHambre barrahambre;
    public EndlessScrollHouse es1;
    public EndlessScrollHouse es2;
    public EndlessScrollHouse es3;
    public EndlessScrollHouse es4;
    public EndlessScrollHouse es5;
    public EndlessScrollHouse es6;

    public SpawningManager spawning;

    void Start()
    {
        menu.enabled = true;
        hud.enabled = false;
    }

    void Update()
    {
        if (Playing)
        {
            tiempoTranscurrido += Time.deltaTime;
            float factorInterpolacion = Mathf.Clamp01(tiempoTranscurrido / duracionMovimiento);
            camera.transform.position = Vector3.Lerp(camera.transform.position, posicionFinal, factorInterpolacion);
            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(rotacionFinal), factorInterpolacion);

            if (tiempoTranscurrido >= duracionMovimiento)
            {
                tiempoTranscurrido = 0f;
            }
        }
    }


    public void StartGame()
    {
        Playing = true;
        menu.enabled = false;
        hud.enabled = true;


        barrahambre.StartComponent();
        es1.StartComponent();
        es2.StartComponent();
        es3.StartComponent();
        es4.StartComponent();
        es5.StartComponent();
        es6.StartComponent();
        spawning.StartComponent();
    }
}
