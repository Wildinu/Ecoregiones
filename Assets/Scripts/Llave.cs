using UnityEngine;
public class Llave : MonoBehaviour
{
    public int numeroLlave = 1; 

    private void Start()
    {
        
        if ((numeroLlave == 1 && GameManager.llave1) || (numeroLlave == 2 && GameManager.llave2))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
          transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (numeroLlave == 1) GameManager.llave1 = true;
            if (numeroLlave == 2) GameManager.llave2 = true;

            
            Destroy(gameObject);
        }
    }
}
