using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    private float deltaTime = 0.0f;
    public Text fpsText;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void LateUpdate()
    {
        float fps = 1.0f / deltaTime;
        string text = string.Format("FPS: {0:F2}", fps);
        fpsText.text = text;
        // 根据帧率设置字体颜色
        if (fps < 60)
        {
            fpsText.color = Color.red;
        }
        else
        {
            fpsText.color = Color.green;
        }
    }
}
