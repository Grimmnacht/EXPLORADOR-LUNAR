using UnityEngine;

public class ComportamentoOVNI : MonoBehaviour
{
    // Configs de Órbita
    public Transform centrodaLua;
    public float velocidadeOrbita = 10f;
    public float alturadaOrbita = 1100.0f;

    // AFD OVNI

    public float tempoMinimoEstado = 4.0f;
    public float tempoMaximoEstado = 10.0f;

    private enum EstadoOVNI
    {
        PARADO,
        ORBITANDO_DIREITA,
        ORBITANDO_ESQUERDA,
        MOVENDO_RETO
    }

    private EstadoOVNI estadoAtual;

    private float temporizadorDoEstado;
    private Vector3 direcaoMovimentoReto;

    void Start()
    {
       if (centrodaLua == null)
        {
            centrodaLua = GameObject.Find("Lua").transform;
        }

        EscolherProximoEstado();

    }

    void Update()
    {
        
        temporizadorDoEstado -= Time.deltaTime;

        if (temporizadorDoEstado <= 0)
        {
            EscolherProximoEstado();
        }

        ExecutarEstadoAtual();

    } 

    void ExecutarEstadoAtual ()
    {
        
        switch (estadoAtual)
        {
            case EstadoOVNI.PARADO:
                break;

            case EstadoOVNI.ORBITANDO_DIREITA:
                transform.RotateAround(centrodaLua.position, Vector3.up, velocidadeOrbita * Time.deltaTime);
                break;

            case EstadoOVNI.ORBITANDO_ESQUERDA:
                transform.RotateAround(centrodaLua.position, Vector3.up, -velocidadeOrbita * Time.deltaTime);
                break;

            case EstadoOVNI.MOVENDO_RETO:
                transform.Translate(direcaoMovimentoReto * velocidadeOrbita * Time.deltaTime, Space.World);
                ManterAltitude();
                break;
        }


    }

    void EscolherProximoEstado ()
    {
       int indexEstado = Random.Range(0,4);

       if (indexEstado == 0)
        {
            estadoAtual = EstadoOVNI.PARADO;
        }
       else if (indexEstado == 1)
        {
            estadoAtual = EstadoOVNI.ORBITANDO_DIREITA;
        }
       else if (indexEstado == 2)
        {
            estadoAtual = EstadoOVNI.ORBITANDO_ESQUERDA;
        }
       else 
        {
            estadoAtual = EstadoOVNI.MOVENDO_RETO;
            direcaoMovimentoReto = Random.onUnitSphere;
            direcaoMovimentoReto.y = 0;
            direcaoMovimentoReto.Normalize();
        }

         temporizadorDoEstado = Random.Range(tempoMinimoEstado, tempoMaximoEstado);

    }

    void ManterAltitude ()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(pos.y, alturadaOrbita, Time.deltaTime * 0.5f);
        Vector3 direcaoDoCentro = (pos - centrodaLua.position).normalized;
        direcaoDoCentro.y = 0;
        float raio = new Vector2(pos.x, pos.z).magnitude;
        float raioDesejado =new Vector2(alturadaOrbita, 0).magnitude;

        Vector3 posDesejada = direcaoDoCentro * raioDesejado;
        pos.x = Mathf.Lerp(pos.x, posDesejada.x, Time.deltaTime * 0.5f);
        pos.z = Mathf.Lerp(pos.z, posDesejada.z, Time.deltaTime * 0.5f);
        transform.position = pos;
    }

}
