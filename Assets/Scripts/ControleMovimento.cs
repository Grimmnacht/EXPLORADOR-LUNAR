using UnityEngine;
using UnityEngine.InputSystem; 

[RequireComponent(typeof(Rigidbody))]
public class ControleMovimento : MonoBehaviour
{
    public float velocidadeCaminhada = 5.0f;
    public float forcaPulo = 3.0f; 

    private Rigidbody rb;
    private Vector2 inputMovimento; 
    private bool estaNoChao = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Esta função é chamada pelo PlayerInput (Move)
    public void OnMove(InputValue value)
    {
        inputMovimento = value.Get<Vector2>();
    }

    // Esta função é chamada pelo PlayerInput (Jump)
    public void OnJump(InputValue value)
    {
        if (value.isPressed && estaNoChao)
        {
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
        }
    }
    
    void FixedUpdate()
    {
        Vector3 direcaoMovimento = new Vector3(inputMovimento.x, 0, inputMovimento.y).normalized;
        Vector3 movimentoRelativo = transform.TransformDirection(direcaoMovimento);
        Vector3 velocidadeAlvo = movimentoRelativo * velocidadeCaminhada;
        velocidadeAlvo.y = rb.linearVelocity.y; 
        
        Vector3 forca = (velocidadeAlvo - rb.linearVelocity);
        forca.x = Mathf.Clamp(forca.x, -50f, 50f);
        forca.z = Mathf.Clamp(forca.z, -50f, 50f);
        forca.y = 0; 
        
        rb.AddForce(forca, ForceMode.VelocityChange);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        estaNoChao = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        estaNoChao = false;
    }
}