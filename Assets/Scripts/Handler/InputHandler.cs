using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputConfig inputConfig;
    private static InputConfig inputConfigCopy;

    private void Awake()
    {
        inputConfigCopy = inputConfig;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        inputConfigCopy = inputConfig;
    }
#endif

    public static float HorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public static float VerticalInput()
    {
        return Input.GetAxis("Vertical");
    }

    public static bool HorizontalAccelerationInput()
    {
        return Input.GetKey(inputConfigCopy.horizontalAcceleration);
    }

    public static bool VerticalAccelerationInput()
    {
        return Input.GetKey(inputConfigCopy.verticalAcceleration);
    }

    public static bool DecelerationInput()
    {
        return Input.GetKey(inputConfigCopy.deceleration);
    }

    public static bool ShootInput()
    {
        return Input.GetKey(inputConfigCopy.shoot);
    }

    public static bool AimInput()
    {
        return Input.GetKey(inputConfigCopy.aim);
    }

    public static bool ReloadInput()
    {
        return Input.GetKeyDown(inputConfigCopy.reload);
    }

    public static bool SpecialActionInput()
    {
        return Input.GetKeyDown(inputConfigCopy.specialAction);
    }

    public static float MouseScroll()
    {
        return Input.GetAxis("Mouse ScrollWheel");
    }
}