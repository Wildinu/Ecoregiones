using UnityEngine;
using TMPro;


public class InteraccionJugador : MonoBehaviour
{
    [Header("Rayo")]
    public Transform rayOrigin;          
    public float distance = 3f;          
    public LayerMask interactiveLayer;   

    [Header("Cartel en pantalla")]
    public GameObject cartel;            
    public TMP_Text textoCartel;         

    [Header("Tecla")]
    public KeyCode teclaInteractuar = KeyCode.E;

    private void Start()
    {
        if (rayOrigin == null && Camera.main != null) rayOrigin = Camera.main.transform;
        MostrarCartel(false);
    }

    private void Update()
    {
        PortalEcosistema portal = null;
        Cartelconinfo info = null;

        Ray rayito = new Ray(rayOrigin.position, rayOrigin.forward);

        if (Physics.Raycast(rayito, out RaycastHit hit, distance, interactiveLayer, QueryTriggerInteraction.Collide))
        {
            portal = hit.collider.GetComponentInParent<PortalEcosistema>();
            info = hit.collider.GetComponentInParent<Cartelconinfo>();
        }

        if (portal != null)
        {
            textoCartel.text = portal.mensaje;
            MostrarCartel(true);

            if (Input.GetKeyDown(teclaInteractuar))
            {
                MostrarCartel(false);
                portal.Interactuar(transform);
            }
        }
        else if (info != null)
        {
            textoCartel.text = info.mensaje;
            MostrarCartel(true);
        }
        else
        {
            MostrarCartel(false);
        }

        }

    private void MostrarCartel(bool visible)
    {
        if (cartel != null && cartel.activeSelf != visible) cartel.SetActive(visible);
    }
}