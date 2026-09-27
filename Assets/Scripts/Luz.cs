using UnityEngine;

public class InteractiveLight : MonoBehaviour
{
    [Header("Componentes")]
    public Light targetLight;

    private void Start()
    {
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }

        TurnOff();
    }

    public void TurnOn()
    {
        if (targetLight != null)
        {
            targetLight.enabled = true;
        }
    }

    public void TurnOff()
    {
        if (targetLight != null)
        {
            targetLight.enabled = false;
        }
    }
}
