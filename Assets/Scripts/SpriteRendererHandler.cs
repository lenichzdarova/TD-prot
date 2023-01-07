
using UnityEngine;

public class SpriteRendererHandler
{
    private SpriteRenderer _spriteRenderer;

    public SpriteRendererHandler(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
    }

    public void SetDirection(bool direction)
    {
        _spriteRenderer.flipX = direction;
    }
}
