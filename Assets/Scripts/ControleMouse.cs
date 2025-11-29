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
    
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        transform.Rotate(Vector3.up * mouseX);

        rotacaoVertical -= mouseY;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -90f, 90f);

        cabecaCamera.localRotation = Quaternion.Euler(rotacaoVertical, 0, 0);
    }
}