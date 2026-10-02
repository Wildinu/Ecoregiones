using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Escena a cargar")]
    public string escenaSimulador = "ProBuilder";

    [Header("Panel de opciones (opcional)")]
    public GameObject panelOpciones;

    private void Start()
    {
        // Por si vuelvo al juego
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (panelOpciones != null) panelOpciones.SetActive(false);
    }

   
    public void Empezar()
    {
        // Empezar en la posicion inicial
        PlayerPosition.hasSavedPosition = false;

        SceneManager.LoadScene(escenaSimulador);
    }

     public void AbrirOpciones()
    {
        if (panelOpciones != null) panelOpciones.SetActive(true);
    }

    
    public void CerrarOpciones()
    {
        if (panelOpciones != null) panelOpciones.SetActive(false);
    }
}
