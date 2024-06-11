using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputConfig", menuName = "Input/InputConfig")]

public class InputConfig : ScriptableObject
{
    public KeyCode horizontalAcceleration = KeyCode.LeftShift;
    public KeyCode verticalAcceleration = KeyCode.Space;
    public KeyCode deceleration = KeyCode.LeftControl;
    public KeyCode shoot = KeyCode.Mouse0;
    public KeyCode aim = KeyCode.Mouse1;
    public KeyCode reload = KeyCode.R;
    public KeyCode specialAction = KeyCode.B;
}
