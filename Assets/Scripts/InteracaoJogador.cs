using UnityEngine;
using UnityEngine.InputSystem;

public class InteracaoJogador : MonoBehaviour
{
    private PortaAFD portaAtual = null;

    public void OnInteract(InputValue value)
    {
        if (value.isPressed && portaAtual != null)
        {
            portaAtual.TrocarEstado();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Porta"))
        {
            portaAtual = other.GetComponent<PortaAFD>();
            Debug.Log("Perto da porta. Pode abrir.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Porta"))
        {
            if (portaAtual == other.GetComponent<PortaAFD>())
            {
                portaAtual = null;
                Debug.Log("Longe da porta.");
            }
        }
    }
}