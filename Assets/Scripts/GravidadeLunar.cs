using UnityEngine;

public class GravidadeLunar : MonoBehaviour
{
    public Transform centroDaLua;

    [Header("Ajustes de Física")]
    public float forcaGravidade = 1.62f; 
    public float multiplicadorQueda = 2.5f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (centroDaLua == null) return;

        Vector3 direcaoParaBaixo = (centroDaLua.position - transform.position).normalized;
        Vector3 vetorGravidadeFinal = direcaoParaBaixo * forcaGravidade;
 
        if (Vector3.Dot(rb.linearVelocity, direcaoParaBaixo) > 0)
        {
  
            vetorGravidadeFinal *= multiplicadorQueda;
        }

    
        rb.AddForce(vetorGravidadeFinal, ForceMode.Acceleration);

        Quaternion rotacaoDesejada = Quaternion.FromToRotation(transform.up, -direcaoParaBaixo) * transform.rotation;
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, rotacaoDesejada, Time.fixedDeltaTime * 10.0f));
    }
}