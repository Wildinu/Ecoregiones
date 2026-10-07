using UnityEngine;

public class LuzProximidad : MonoBehaviour
{
    public Light luz;                  
    public float distanciaParaPrender = 5f;

    private Transform jugador;

    private void Start()
    {
        if (luz == null) luz = GetComponentInChildren<Light>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) jugador = player.transform;
        

        if (luz != null) luz.enabled = false;
    }

    private void Update()
    {
        if (jugador == null || luz == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        
        luz.enabled = distancia < distanciaParaPrender;
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaParaPrender);
    }
}