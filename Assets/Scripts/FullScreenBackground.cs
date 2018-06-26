using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenBackground : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private float cameraHeight;
    Vector2 cameraSize, spriteSize, scale;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraHeight = Camera.main.orthographicSize * 2f;
        cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        spriteSize = spriteRenderer.sprite.bounds.size;
        //scale = transform.localScale;
        scale = new Vector2(1f, 1f);
        scale *= cameraSize.x / spriteSize.x;
        transform.position = Vector2.zero;
        transform.localScale = scale;
    }
}
