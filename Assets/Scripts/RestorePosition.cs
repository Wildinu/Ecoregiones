using UnityEngine;

public class RestorePlayerPosition : MonoBehaviour
{
    private void Start()
    {
        
        if (PlayerPosition.hasSavedPosition)
        {
            
            CharacterController controller = GetComponent<CharacterController>();
            if (controller != null) controller.enabled = false;

           
            transform.position = PlayerPosition.lastPosition;
            transform.rotation = PlayerPosition.lastRotation;

            if (controller != null) controller.enabled = true;

            
            PlayerPosition.hasSavedPosition = false;
        }
    }
}
