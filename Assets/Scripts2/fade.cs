using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public Image Fade_panel;
    float time = 0f;
    float Fade_time = 1f;

    public bool finish_fading = false;

    public void Fading()
    {
        StartCoroutine(fading_coroutine());
    }

    IEnumerator fading_coroutine()
    {
        Fade_panel.gameObject.SetActive(true);
        Color alpha = Fade_panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / Fade_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Fade_panel.color = alpha;
            yield return null;
        }
        finish_fading = true;
        yield return null;
    }
}
