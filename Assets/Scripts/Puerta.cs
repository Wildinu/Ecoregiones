using UnityEngine;

public class Puerta : MonoBehaviour
{
    public float distanciaParaAbrir = 20f;

    private Transform jugador;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) jugador = player.transform;
         }

    private void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaParaAbrir && GameManager.TieneLasDosLlaves())
        {

            Destroy(gameObject);
        }
    }
}