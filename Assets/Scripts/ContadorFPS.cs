using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorFPS : MonoBehaviour
{
    [SerializeField] private Text fpsTxt;

    float gameTime;
    float fps;

    void Update()
    {
        gameTime += (Time.deltaTime - gameTime) * 0.1f;
        fps = 1.0f / gameTime;
        fpsTxt.text = fps.ToString();
    }
}