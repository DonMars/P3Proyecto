using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputConfig inputConfig;

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
        // return Input.GetKey(InputConfig.horizontalAcceleration);
        return false;
    }

    public static bool VerticalAccelerationInput()
    {
        return false;
    }

    public static bool DecelerationInput()
    {
        return false;
    }

    public static bool ShootInput()
    {
        return false;
    }
}
