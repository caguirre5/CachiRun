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
    public float duracionMovimiento = 1f;

    // Tiempo transcurrido desde el inicio del movimiento
    private float tiempoTranscurrido = 0f;

    public Canvas hud;
    public Canvas menu;
    void Start()
    {
        menu.enabled = true;
        hud.enabled = false;
    }

    void Update()
    {

    }


    public void StartGame()
    {
        Playing = true;
        menu.enabled = false;
        hud.enabled = true;
        Debug.Log(Playing);
        // Incrementa el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Calcula el valor de interpolación entre 0 y 1 basado en el tiempo transcurrido
        float factorInterpolacion = Mathf.Clamp01(tiempoTranscurrido / duracionMovimiento);

        // Interpola la posición y rotación del objeto gradualmente hacia las posiciones y rotación finales
        // camera.transform.position = Vector3.Lerp(camera.transform.position, posicionFinal, factorInterpolacion);
        // camera.transform.rotation = Quaternion.Euler(Vector3.Lerp(camera.transform.rotation.eulerAngles, rotacionFinal, factorInterpolacion));

        camera.transform.position = posicionFinal;

        // Si el tiempo transcurrido alcanza o supera la duración del movimiento, detenemos la interpolación
        if (tiempoTranscurrido >= duracionMovimiento)
        {
            // Restablece el tiempo transcurrido
            tiempoTranscurrido = 0f;
        }
    }
}
