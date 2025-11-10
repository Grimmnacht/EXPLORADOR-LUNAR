using UnityEngine;

public class GravidadeLunar : MonoBehaviour
{
    public Transform centroDaLua;
    public float forcaGravidade = 1.62f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // 1. CALCULAR A DIREÇÃO DA GRAVIDADE 
        Vector3 direcaoGravidade = (centroDaLua.position - transform.position).normalized;

        // 2. APLICAR A FORÇA DA GRAVIDADE
        rb.AddForce(direcaoGravidade * forcaGravidade, ForceMode.Acceleration);

        // 3. ORIENTAR O ASTRONAUTA 
        Vector3 direcaoParaCima = -direcaoGravidade;

        Quaternion rotacaoDesejada = Quaternion.FromToRotation(transform.up, direcaoParaCima) * transform.rotation;
        
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, rotacaoDesejada, Time.fixedDeltaTime * 8.0f));
    }
}