using UnityEngine;

public class ComportamentoOVNI : MonoBehaviour
{
    [Header("Configurações")]
    public Transform centroDaLua;
    public float velocidadeOrbita = 30.0f;
    public float velocidadeGiroProprio = 100.0f;

    [Header("IA")]
    public float tempoMinimoEstado = 5.0f;
    public float tempoMaximoEstado = 10.0f;

    // Estados
    private enum EstadoOVNI { PARADO, ORBITA_HORIZONTAL, ORBITA_POLAR, ORBITA_DIAGONAL }
    private EstadoOVNI estadoAtual;
    private float temporizador;
    
    
    private Vector3 eixoOrbitaAtual;

    void Start()
    {
        if (centroDaLua == null) centroDaLua = GameObject.Find("Lua").transform;
        
        
        transform.rotation = Quaternion.identity;
        
        transform.up = (transform.position - centroDaLua.position).normalized;

        EscolherNovoEstado();
    }

    void Update()
    {
        temporizador -= Time.deltaTime;
        if (temporizador <= 0) EscolherNovoEstado();

        ExecutarMovimento();
    }

    void ExecutarMovimento()
    {
       
        transform.Rotate(Vector3.up, velocidadeGiroProprio * Time.deltaTime, Space.Self);

        
        if (estadoAtual != EstadoOVNI.PARADO)
        {
          
            transform.RotateAround(centroDaLua.position, eixoOrbitaAtual, velocidadeOrbita * Time.deltaTime);
        }
        
       
        Vector3 direcaoGravidade = (transform.position - centroDaLua.position).normalized;
        
        
        Quaternion rotacaoAlvo = Quaternion.FromToRotation(transform.up, direcaoGravidade) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * 5.0f);
    }

    void EscolherNovoEstado()
    {
        int sorteio = Random.Range(0, 100);

        if (sorteio < 10) 
        {
            estadoAtual = EstadoOVNI.PARADO;
        }
        else
        {
           
            int tipoOrbita = Random.Range(0, 3);
            
            if (tipoOrbita == 0) 
            {
                estadoAtual = EstadoOVNI.ORBITA_HORIZONTAL;
                eixoOrbitaAtual = Vector3.up; 
            }
            else if (tipoOrbita == 1) 
            {
                estadoAtual = EstadoOVNI.ORBITA_POLAR;
                eixoOrbitaAtual = Vector3.right; 
            }
            else 
            {
                estadoAtual = EstadoOVNI.ORBITA_DIAGONAL;
                
                eixoOrbitaAtual = Random.onUnitSphere; 
            }
        }

        temporizador = Random.Range(tempoMinimoEstado, tempoMaximoEstado);
    }
}