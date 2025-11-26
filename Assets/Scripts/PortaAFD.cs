using UnityEngine;

public class PortaAFD : MonoBehaviour
{
    public enum EstadoPorta { FECHADA, ABERTA }
    
    [Header("Estado Atual")]
    public EstadoPorta estadoAtual = EstadoPorta.FECHADA;

    [Header("Configurações")]
    public float anguloAberta = 90f; 
    public float velocidade = 2.0f;

    [Header("Ajuste de Eixo (Mude aqui se abrir errado)")]
    public Vector3 eixoDeRotacao = new Vector3(0, 1, 0); 

    private Quaternion rotacaoInicialLocal;
    private Quaternion rotacaoFinalLocal;

    void Start()
    {
        rotacaoInicialLocal = transform.localRotation;
      
        Vector3 rotacaoCalculada = eixoDeRotacao * anguloAberta;

        rotacaoFinalLocal = rotacaoInicialLocal * Quaternion.Euler(rotacaoCalculada);
    }

    void Update()
    {
        if (estadoAtual == EstadoPorta.ABERTA)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacaoFinalLocal, Time.deltaTime * velocidade);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacaoInicialLocal, Time.deltaTime * velocidade);
        }
    }

    public void TrocarEstado()
    {
        if (estadoAtual == EstadoPorta.FECHADA)
            estadoAtual = EstadoPorta.ABERTA;
        else
            estadoAtual = EstadoPorta.FECHADA;
    }
}