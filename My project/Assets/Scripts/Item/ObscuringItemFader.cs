using System.Collections;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class ObscuringItemFader : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    public void FadeIn()
    {
        StartCoroutine(FadeInRountine());
    }

    private IEnumerator FadeInRountine()
    {
        float currentAlpha = spriteRenderer.color.a;
        float distance = 1 - currentAlpha;

        while (1f - currentAlpha > 0.01f)
        {
            currentAlpha = currentAlpha + distance / Setting.targetAlpha * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    private IEnumerator FadeOutRoutine()
    {
        float currentAlpha = spriteRenderer.color.a;
        float distance = currentAlpha - Setting.targetAlpha;

        while(currentAlpha - Setting.targetAlpha > 0.01f)
        {
            currentAlpha = currentAlpha - distance / Setting.targetAlpha * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha); 
            yield return null;
        }
        spriteRenderer.color = new Color(1f,1f,1f, Setting.targetAlpha);
    }
}
