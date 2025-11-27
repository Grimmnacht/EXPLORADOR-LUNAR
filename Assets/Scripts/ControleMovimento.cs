using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ControleMovimento : MonoBehaviour
{
    [Header("Configurações")]
    public float velocidadeCaminhada = 8.0f; 
    public float forcaPulo = 3.0f; 

    [Header("Referências")]
    public Transform cameraVR; 

    private Rigidbody rb;
    private Vector2 inputMovimento; 
    private bool estaNoChao = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (cameraVR == null)
        {
            cameraVR = Camera.main.transform;
        }
    }
    
    public void OnMove(InputValue value)
    {
        inputMovimento = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && estaNoChao)
        {
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
        }
    }
    
    void FixedUpdate()
    {
        Vector3 frenteDaCamera = cameraVR.forward;
        Vector3 ladoDaCamera = cameraVR.right;

       
        frenteDaCamera.y = 0;
        ladoDaCamera.y = 0;
 
        frenteDaCamera.Normalize();
        ladoDaCamera.Normalize();

       
        Vector3 direcaoDesejada = (frenteDaCamera * inputMovimento.y + ladoDaCamera * inputMovimento.x).normalized;

        Vector3 velocidadeAlvo = direcaoDesejada * velocidadeCaminhada;
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