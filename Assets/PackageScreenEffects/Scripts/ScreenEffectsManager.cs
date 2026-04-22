using UnityEngine;

public class ScreenEffectsManager : MonoBehaviour
{
    public ScreenShake screenShake;
    public ScreenFlash screenFlash;

    public void TriggerShake(float duration, float magnitude)
    {
        Debug.Log("Triggering shake");
        screenShake.startShake(duration, magnitude);
    }

    public void TriggerFlash(float duration, Color color)
    {
        Debug.Log("Triggering flash");
        screenFlash.startFlash(duration, color);
    }
}
