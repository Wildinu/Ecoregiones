using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemDetection : MonoBehaviour
{
    public Transform rayOrigin;
    public float distance = 5f;
    public LayerMask interactiveLayer;

    
    private InteractiveLight lastLightTarget;

    private void Update()
    {
        Ray rayito = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit rayitoHit;

        if (Physics.Raycast(rayito, out rayitoHit, distance, interactiveLayer))
        {
            GameObject hitObject = rayitoHit.collider.gameObject;

            
            InteractiveLight target = hitObject.GetComponent<InteractiveLight>();

            if (target != null)
            {
                
                if (lastLightTarget != null && lastLightTarget != target)
                {
                    lastLightTarget.TurnOff();
                }

                
                target.TurnOn();
                lastLightTarget = target;
            }
            else
            {
              
                ClearLastLight();
            }
        }
        else
        {
         
            ClearLastLight();
        }

        
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * distance, Color.white);
    }

    private void ClearLastLight()
    {
        if (lastLightTarget != null)
        {
            lastLightTarget.TurnOff();
            lastLightTarget = null;
        }
    }
}
