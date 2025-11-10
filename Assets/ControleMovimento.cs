using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ControleMovimento : MonoBehaviour
{
    // Ajuste a velocidade de caminhada aqui
    public float velocidadeCaminhada = 5.0f;
    
    // Ajuste a força do pulo 
    public float forcaPulo = 3.0f; 

    private Rigidbody rb;
    private Vector3 direcaoMovimento;

    // Checa se o astronauta está tocando o chão
    private bool estaNoChao = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Lendo as teclas WASD ou Setas
        
        float inputHorizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float inputVertical = Input.GetAxisRaw("Vertical"); // W/S

        // 2. Criando o vetor de direção
        
        direcaoMovimento = new Vector3(inputHorizontal, 0, inputVertical).normalized;

        // 3. Checando o Pulo 
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
           
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // 4. Aplicando o movimento no FixedUpdate 
        Vector3 movimentoRelativo = transform.TransformDirection(direcaoMovimento);
        
        // 5. Calculando a velocidade alvo
        Vector3 velocidadeAlvo = movimentoRelativo * velocidadeCaminhada;
        
        // 6. Ajustando a velocidade alvo para o eixo Y
        velocidadeAlvo.y = rb.linearVelocity.y;

        // 7. Calculando a força necessária para alcançar a velocidade alvo
        Vector3 forca = (velocidadeAlvo - rb.linearVelocity);
        
        // 8. Limitando a força
        forca.x = Mathf.Clamp(forca.x, -50f, 50f); // Limita a força
        forca.z = Mathf.Clamp(forca.z, -50f, 50f);
        forca.y = 0; // O 'GravidadeLunar' e o pulo cuidam do Y

        rb.AddForce(forca, ForceMode.VelocityChange);
    }

    
    void OnCollisionStay(Collision collisionInfo)
    {
        // Se estivermos em contato com o chão, marcamos como "no chão"
        estaNoChao = true;
    }

    // Se sairmos do chão, marcamos como "no ar"
    void OnCollisionExit(Collision collisionInfo)
    {
        estaNoChao = false;
    }
}