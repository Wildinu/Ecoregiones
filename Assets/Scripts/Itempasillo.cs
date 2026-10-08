using UnityEngine;

public class Itempasillo : MonoBehaviour
{

    public int numeroLlave = 1; 

    private Renderer[] meshes;

    private void Start()
    {
                meshes = GetComponentsInChildren<Renderer>();
    }

    private void Update()
    {
        bool tieneLlave = (numeroLlave == 1 && GameManager.llave1) ||
                          (numeroLlave == 2 && GameManager.llave2);

        foreach (Renderer r in meshes)
        {
            r.enabled = tieneLlave;
        }
    }
}
