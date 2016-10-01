using UnityEngine;
using System.Collections;

public class TransformLerpAnimation
{
    private Vector3 startPos;
    private Vector3 endPos;
    private float duration;

    public TransformLerpAnimation(Vector3 startPos, Vector3 endPos, float duration)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        this.duration = duration;
    }

    public IEnumerator AnimationCoroutine(GameObject go)
    {
        float i = 0f;
        while (i <= 1f)
        {
            i += Time.deltaTime / duration;
            go.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
