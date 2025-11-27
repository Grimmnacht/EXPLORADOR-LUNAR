using UnityEngine;
using UnityEngine.Playables; 
using UnityEngine.InputSystem;

public class GerenciadorCutscene : MonoBehaviour
{
    [Header("Timelines")]
    public PlayableDirector timelineIntro; 
    public PlayableDirector timelineFinal; 

    [Header("Controles")]
    public PlayerInput inputDoJogador; 
    public GameObject astronauta; 
    public Transform pontoEspectador; 
    public Transform pontoInicial;    

    [Header("UI")]
    public GameObject objetoTextoUI; 
    public GameObject painelFade; 

    [Header("Foguetes")]
    public GameObject fogueteEstatico; 
    public GameObject fogueteCutscene; 

    void Start()
    {
  
        if (inputDoJogador != null) inputDoJogador.DeactivateInput();
        if (objetoTextoUI != null) objetoTextoUI.SetActive(false);
        if (fogueteEstatico != null) fogueteEstatico.SetActive(false);
        if (fogueteCutscene != null) fogueteCutscene.SetActive(true);

        if (timelineFinal != null) timelineFinal.Stop();

        if (pontoInicial != null && astronauta != null)
        {
            astronauta.transform.position = pontoInicial.position;
            astronauta.transform.rotation = pontoInicial.rotation;

            Rigidbody rb = astronauta.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = true;
        }

      
        if (timelineIntro != null) timelineIntro.Play();
        
        Invoke("ComecarJogoReal", 10.5f);
    }

    void ComecarJogoReal()
    {
      
        if (fogueteCutscene != null) fogueteCutscene.SetActive(false);
        if (fogueteEstatico != null) fogueteEstatico.SetActive(true);

       
        if (inputDoJogador != null) inputDoJogador.ActivateInput();
        if (objetoTextoUI != null) objetoTextoUI.SetActive(true);

       
        if (astronauta != null)
        {
            Rigidbody rb = astronauta.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false; // Volta a ter gravidade
        }
    }

    public void IniciarSequenciaFinal()
    {
        if (inputDoJogador != null) inputDoJogador.DeactivateInput();
        Invoke("PrepararCutsceneFinal", 3.0f);
    }

    void PrepararCutsceneFinal()
    {
        CanvasGroup fade = painelFade.GetComponent<CanvasGroup>();
        if (fade != null) fade.alpha = 1; 

        if (objetoTextoUI != null) objetoTextoUI.SetActive(false);

        if (fogueteEstatico != null) fogueteEstatico.SetActive(false);
        if (fogueteCutscene != null) fogueteCutscene.SetActive(true);

     
        Rigidbody rbAstronauta = astronauta.GetComponent<Rigidbody>();
        if (rbAstronauta != null) rbAstronauta.isKinematic = true;
        
    
        astronauta.transform.position = pontoEspectador.position;
        astronauta.transform.LookAt(fogueteCutscene.transform);

        if (timelineFinal != null) timelineFinal.Play();

        Invoke("FecharJogo", 15.0f);
    }

    void FecharJogo()
    {
        Application.Quit();
    }
}