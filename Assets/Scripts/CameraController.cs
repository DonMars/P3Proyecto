using UnityEngine;

namespace Profe
{

    public class CameraController : MonoBehaviour
    {

        [SerializeField] private float sensitivity = 2.0f;
        [SerializeField] private float smooth = 2.0f;

        [SerializeField] private float maxAngleY = 60;
        [SerializeField] private float minAngleY = -66;

        private Transform objectToRotate;

        private Vector2 velocity;
        private Vector2 cursorVelocity;
        private Vector2 smoothVeloctiy;

        private void Start()
        {
            StartSettings();
        }

        private void Update()
        {
            RotateCamera();
        }

        private void StartSettings()
        {
            // Sirve para obtener el transform en caso que este script este emparentado a otro objeto
            if(transform.parent != null)
            {
                objectToRotate = transform.parent.GetComponent<Transform>();
            }
            else
            {
                objectToRotate = this.transform;
            }

            Cursor.lockState = CursorLockMode.Locked; // Desaparece y bloquea el mouse en el centro de la pantalla
            Cursor.visible = false; // Desaparece el mouse de la pantalla
        }

        private void RotateCamera()
        {
            // Consigue el input del mouse
            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), 
                Input.GetAxisRaw("Mouse Y"));

            // Te da la velocidad a la que se va a mover el cursor // Input x Sensibilidad
            cursorVelocity = Vector2.Scale(mouseInput, Vector2.one * sensitivity);

            // Suavizar la camara
            smoothVeloctiy = Vector2.Lerp(smoothVeloctiy, cursorVelocity, 1 / smooth);
            velocity += smoothVeloctiy;
            // Esto nos limita el angulo maximo en que podemos rotar la camara hacia arriba y hacia abajo
            velocity.y = Mathf.Clamp(velocity.y, minAngleY, maxAngleY);

            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            objectToRotate.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        }


    }

}