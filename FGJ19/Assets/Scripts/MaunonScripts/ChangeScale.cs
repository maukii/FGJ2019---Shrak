using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    public AnimationCurve ScaleCurve;
    public Vector2 startScale, endScale;
    public float effectTime = 1;
    public bool ready = false;

    public void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        ready = false;
        transform.localScale = startScale;

        float time = 0;
        float percent = 0;
        float lastTime = Time.realtimeSinceStartup;

        do
        {
            time += Time.realtimeSinceStartup - lastTime;
            lastTime = Time.realtimeSinceStartup;

            percent = Mathf.Clamp01(time / effectTime);
            Vector2 tempScale = Vector2.LerpUnclamped(startScale, endScale, ScaleCurve.Evaluate(percent));

            transform.localScale = tempScale;
            yield return null;

        } while (percent < 1);

        transform.localScale = endScale;
        ready = true;
    }

}