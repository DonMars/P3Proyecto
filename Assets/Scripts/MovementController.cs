using System;
using UnityEngine;

namespace Profe
{

    [RequireComponent(typeof(Rigidbody), typeof(GroundCheck))]
    public class MovementController : MonoBehaviour
    {
        /// <summary>
        /// readonly, se usa cuando no quieres que nadie, ni si quiera tu
        /// modifique el valor de una variable cuando se referencía en otro script
        /// unicamente la necesitas leer
        /// 
        /// public se usa cuando si es necesario modificar esa variable en otro script
        /// 
        /// private se usa cuando no quieres que ningun otro script tenga acceso a esa variable
        /// para evitar futuros fallos
        /// 
        /// SerializeField lo usas cuando estas testeando y necesitas ver la variable en el inspector
        /// 
        /// const cuando no quieres que el valor de esa variable cambie, y normalmente se le pone const
        /// a una variable que ya fue testeada con anterioridad
        /// 
        /// protected es que solo puedes usar esas variables en clases que hereden de donde fueron declarads
        /// se suele usar cuando hacer herencia, y para no crear un conflicto en variables del mismo namespace que
        /// se llamen igual
        /// </summary>

        private Rigidbody rbPlayer;
        private GroundCheck check;

        private void Awake()
        {
            rbPlayer = GetComponent<Rigidbody>();
            check = GetComponent<GroundCheck>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            Movement();
        }

        private void FixedUpdate()
        {
            Jump();
        }

        #region Movimiento

        [SerializeField]private  float walkSpeed = 5.5f;
        [SerializeField]private float runSpeed = 7.7f;
        [SerializeField]private float crouchSpeed = 3.9f;

        private void Movement()
        {

            rbPlayer.velocity = transform.localRotation * new Vector3(InputHandler.HorizontalInput(), 0, InputHandler.VerticalInput()) * (Time.deltaTime * Speed());
        }

        private float Speed()
        {
            return InputHandler.DecelerationInput() ? crouchSpeed : InputHandler.HorizontalAccelerationInput() ? runSpeed : walkSpeed;
        }

        #endregion

        #region Salto

        [SerializeField] private float jumpForce = 10;

        private void Jump()
        {
            if (InputHandler.VerticalAccelerationInput() && check.IsGrounded())
            {
                rbPlayer.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            }
        }

        private bool JumpInput()
        {
            return Input.GetKey(KeyCode.Space);
        }

        #endregion
    }
}