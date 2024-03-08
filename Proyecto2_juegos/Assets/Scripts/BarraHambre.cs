using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BarraHambre : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;

    public TextMeshProUGUI pointsText;
    public int Cookies = 0;

    public float countdownTime = 60f; // Valor inicial del contador en segundos
    private float currentTime; // Variable para almacenar el tiempo actual

    public MenuController menucontroller;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
        if (menucontroller.Playing)
        {

            InvokeRepeating("DecreaseCountdown", 0.5f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        if (vidaActual <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        pointsText.text = "" + Cookies;
    }

    public void RevisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
    }

    void DecreaseCountdown()
    {
        // Resta 1 al tiempo actual
        vidaActual -= 1f;

    }
}
