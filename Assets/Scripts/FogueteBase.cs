using UnityEngine;

public class FogueteBase : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        InventarioPilha inventario = other.GetComponent<InventarioPilha>();

        if (inventario != null)
        {
            inventario.TentarFinalizarMissao();
        }
    }
}