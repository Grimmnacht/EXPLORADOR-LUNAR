using UnityEngine;

public class MinerioPulsante : MonoBehaviour
{
    [Header("Configuração do Brilho")]
    public float velocidadePulso = 2.0f; 
    public float brilhoMinimo = 0.3f;    
    public float brilhoMaximo = 1.0f;    
    private Material mat;
    private Color corOriginal;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
      
        corOriginal = mat.color;
    }

    void Update()
    {
        float onda = Mathf.PingPong(Time.time * velocidadePulso, 1.0f);
     
        float alphaFinal = Mathf.Lerp(brilhoMinimo, brilhoMaximo, onda);

        Color novaCor = new Color(corOriginal.r, corOriginal.g, corOriginal.b, alphaFinal);
        mat.color = novaCor;
    }
}