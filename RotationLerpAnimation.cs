using UnityEngine;
using System.Collections;

public class RotationLerpAnimation
{
    private float startAngle;
    private float endAngle;
    private float duration;

    public RotationLerpAnimation(float startAngle, float endAngle, float duration)
    {
        this.startAngle = startAngle;
        this.endAngle = endAngle;
        this.duration = duration;
    }

    public IEnumerator AnimationCoroutine(GameObject go)
    {
        float i = 0f;
        while (i <= 1f)
        {
            i += Time.deltaTime / duration;
            go.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Lerp(startAngle, endAngle, i)));
            yield return null;
        }
    }
}
