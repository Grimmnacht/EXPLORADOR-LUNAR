using UnityEngine;
using System.Collections.Generic; 
using TMPro; 

public class InventarioPilha : MonoBehaviour
{
    [Header("Configurações do Autômato")]
    public int metaDeColeta = 5; 
    
    [Header("Interface (UI)")]
    public TextMeshProUGUI textoInventario; 
    public GameObject telaDeVitoria;        

    private Stack<string> pilhaDeMinerios = new Stack<string>();

    void Start()
    {
        AtualizarUI();
        if (telaDeVitoria != null) telaDeVitoria.SetActive(false);
    }

    // OPERAÇÃO PUSH 
    public void ColetarMinerio(GameObject minerio)
    {
        pilhaDeMinerios.Push("Minerio");
        
        if (minerio.GetComponent<Collider>() != null)
        {
            minerio.GetComponent<Collider>().enabled = false;
        }

        Destroy(minerio, 0.1f);
        

        Debug.Log("PUSH: Minério coletado. Tamanho da Pilha: " + pilhaDeMinerios.Count);
        AtualizarUI();
    }

    // OPERAÇÃO POP 
    public void TentarFinalizarMissao()
    {
        int quantidadeTotal = pilhaDeMinerios.Count;

        if (quantidadeTotal >= metaDeColeta)
        {
            
            while (pilhaDeMinerios.Count > 0)
            {
                pilhaDeMinerios.Pop();
            }

            Debug.Log("POP GERAL: Pilha esvaziada. Missão Cumprida!");
            
            
            CompletarJogo();
        }
        else
        {
            Debug.Log("REJEITADO: Pilha insuficiente. Faltam: " + (metaDeColeta - quantidadeTotal));
        }
    }

    void CompletarJogo()
    {
        if (textoInventario != null) 
            textoInventario.text = "MISSÃO CUMPRIDA!\nRETORNANDO À TERRA...";
            
        // --- CÓDIGO ATUALIZADO (SEM AVISO AMARELO) ---
        FindFirstObjectByType<GerenciadorCutscene>().IniciarSequenciaFinal();
    }
    void AtualizarUI()
    {
        if (textoInventario != null)
        {
            textoInventario.text = "Minérios: " + pilhaDeMinerios.Count + " / " + metaDeColeta;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Minerio"))
        {
            ColetarMinerio(other.gameObject);
        }
    }
}