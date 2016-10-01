using UnityEngine;
using System.Collections;

public class ColorLerpAnimation
{
    private Color c1;
    private Color c2;
    private float t;

    public ColorLerpAnimation(Color c1, Color c2, float t)
    {
        this.c1 = c1;
        this.c2 = c2;
        this.t  = t;
    }
   
    public IEnumerator AnimationCoroutine(SpriteRenderer sprite)
    {
        float i = 0f;
        while (i <= 1f)
        {
            i += Time.deltaTime / t;
            sprite.color = Color.Lerp(c1, c2, i);
            yield return null;
        }
    }
}
