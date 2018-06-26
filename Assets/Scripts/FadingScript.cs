using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingScript : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float speed;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    private void OnGUI()
    {
        alpha += fadeDir * speed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return speed;
    }

    private void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    }
}
