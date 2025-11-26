using UnityEngine;

public class EventoAsteroide : MonoBehaviour
{
    [Header("Configuração")]
    public GameObject asteroide;      
    public Transform pontoDestino;     
    public float velocidade = 50.0f;   
    public float velocidadeRotacao = 30.0f; 

    private bool eventoAtivo = false;

    void Update()
    {
        if (eventoAtivo && asteroide != null)
        {
    
            asteroide.transform.position = Vector3.MoveTowards(
                asteroide.transform.position, 
                pontoDestino.position, 
                velocidade * Time.deltaTime
            );

            asteroide.transform.Rotate(Vector3.one * velocidadeRotacao * Time.deltaTime);

           
            if (Vector3.Distance(asteroide.transform.position, pontoDestino.position) < 1.0f)
            {
                asteroide.SetActive(false); // Some com ele
                eventoAtivo = false; // Para o script
                Debug.Log("Asteroide completou a viagem.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!eventoAtivo && (other.CompareTag("Player") || other.CompareTag("MainCamera"))) 
        {
            eventoAtivo = true;
            Debug.Log("Evento de Região disparado: Asteroide!");
          
        }
    }
}