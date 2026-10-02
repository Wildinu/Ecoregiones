using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalEcosistema : MonoBehaviour
{
    [Header("Destino")]
    [Tooltip("Nombre exacto de la escena del ecosistema (tiene que estar en Build Profiles)")]
    public string sceneToLoad;

    [Header("Cartel")]
    public string mensaje = "Presioná E para ir al ecosistema";

   
    public void Interactuar(Transform jugador)
    {
        
        PlayerPosition.lastPosition = jugador.position;
        PlayerPosition.lastRotation = jugador.rotation;
        PlayerPosition.hasSavedPosition = true;

        SceneManager.LoadScene(sceneToLoad);
    }
}