using UnityEngine;

public class ControleMouse : MonoBehaviour
{
    public Transform cabecaCamera;
    
    public float sensibilidadeMouse = 2.0f;
    
    private float rotacaoVertical = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. Lendo o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        // 2. Rotação Horizontal 
        transform.Rotate(Vector3.up * mouseX);

        // 3. Rotação Vertical 
        rotacaoVertical -= mouseY;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -90f, 90f);

        // Aplicamos essa rotação apenas à *cabeça* (a Câmera)
        cabecaCamera.localRotation = Quaternion.Euler(rotacaoVertical, 0, 0);
    }
}