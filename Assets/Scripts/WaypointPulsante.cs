using UnityEngine;

public class WaypointPulsante : MonoBehaviour
{
    public float velocidadePulso = 2.0f;
    public float transparenciaMinima = 0.1f;
    public float transparenciaMaxima = 0.6f;
    
    private Material mat;
    private Color corOriginal;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        corOriginal = mat.color;
    }

    void Update()
    {
        float alpha = Mathf.PingPong(Time.time * velocidadePulso, 1.0f);
   
        float alphaFinal = Mathf.Lerp(transparenciaMinima, transparenciaMaxima, alpha);

        Color novaCor = new Color(corOriginal.r, corOriginal.g, corOriginal.b, alphaFinal);
        mat.color = novaCor;
    }
}