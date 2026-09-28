using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
    public string sceneToLoad;
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            
            PlayerPosition.lastPosition = other.transform.position;
            PlayerPosition.lastRotation = other.transform.rotation;
            PlayerPosition.hasSavedPosition = true;

            
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}