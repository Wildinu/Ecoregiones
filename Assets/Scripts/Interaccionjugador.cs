using UnityEngine;
using TMPro;


public class InteraccionJugador : MonoBehaviour
{
    [Header("Rayo")]
    public Transform rayOrigin;          
    public float distance = 2f;          
    public LayerMask interactiveLayer;   

    [Header("Cartel en pantalla")]
    public GameObject cartel;            
    public TMP_Text textoCartel;         

    [Header("Tecla")]
    public KeyCode teclaInteractuar = KeyCode.E;

    private PortalEcosistema portalActual;

    private void Start()
    {
        if (rayOrigin == null && Camera.main != null) rayOrigin = Camera.main.transform;
        MostrarCartel(false);
    }

    private void Update()
    {
        portalActual = null;

        Ray rayito = new Ray(rayOrigin.position, rayOrigin.forward);

        
        if (Physics.Raycast(rayito, out RaycastHit hit, distance, interactiveLayer, QueryTriggerInteraction.Collide))
        {
            
            portalActual = hit.collider.GetComponentInParent<PortalEcosistema>();
        }

        if (portalActual != null)
        {
            if (textoCartel != null) textoCartel.text = portalActual.mensaje;
            MostrarCartel(true);

            if (Input.GetKeyDown(teclaInteractuar))
            {
                MostrarCartel(false);
                portalActual.Interactuar(transform);
            }
        }
        else
        {
            MostrarCartel(false);
        }

        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * distance, Color.green);
    }

    private void MostrarCartel(bool visible)
    {
        if (cartel != null && cartel.activeSelf != visible) cartel.SetActive(visible);
    }
}
