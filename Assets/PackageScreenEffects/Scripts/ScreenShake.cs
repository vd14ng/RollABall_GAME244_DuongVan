using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 initPos;

    void Start()
    {
        // hold initial position
        initPos = transform.position;
    }
    
    public void startShake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        //initialize elapsed time
        float timer = 0;
        // while elapsed time is less than duration
        while (timer < duration)
        {
            //random range between -1 and 1 times the magnitude
            float x = Random.Range(-1.0f, 1.0f) * magnitude;
            float y = Random.Range(-1.0f, 1.0f) * magnitude;
            
            //Debug.Log(x);
            //Debug.Log(y);
            
            //transform the position
            transform.localPosition = initPos + new Vector3(x, y, 0f);
            
            //recalculate the elapsed time
            timer += Time.deltaTime;
            yield return null;
        }
        //return to initial position
        transform.localPosition = initPos;
    }
}
