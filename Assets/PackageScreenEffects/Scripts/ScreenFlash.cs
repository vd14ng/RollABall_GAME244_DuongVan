using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image overlay;
    public void startFlash(float duration, Color color)
    {
        StartCoroutine(Flash(duration, color));
    }

    private IEnumerator Flash(float duration, Color color)
    {
        //set the color RGB style and set the opacity to half
        overlay.color = new Color(color.r, color.g, color.b, 0.5f);

        //wait for the duration
        yield return new WaitForSeconds(duration);

        //set the color to white and zero opacity
        overlay.color = new Color(0, 0, 0, 0);
    }
}
