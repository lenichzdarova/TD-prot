using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererHandler
{
    private SpriteRenderer _spriteRenderer;

    public SpriteRendererHandler(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
    }

    public void OnDirectionCheck(bool direction)
    {
        _spriteRenderer.flipX = direction;
    }
}
