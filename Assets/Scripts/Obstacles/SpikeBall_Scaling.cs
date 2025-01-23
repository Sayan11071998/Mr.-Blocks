using UnityEngine;

public class SpikeBall_Scaling : MonoBehaviour
{
    public float rotationAngle = 90.0f;

    private float scalingFactor = 1.0f;
    private float currentScale;
    public float scalingSpeed = 15.0f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    public float scaleDelay = 2.0f;
    private bool isWaiting = false;
    private float timer = 0f;

    void Start()
    {
        currentScale = minScale;
        ApplyCurrentScale();
    }

    void Update()
    {
        RotateSpikeBall();
        
        if (isWaiting)
            HandleWaiting();
        else
            ScaleSpikeBall();
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

    private void HandleWaiting()
    {
        timer += Time.deltaTime;

        if (timer >= scaleDelay)
        {
            isWaiting = false;
            timer = 0f;
        }
    }

    private void ScaleSpikeBall()
    {
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);

        if (currentScale >= maxScale || currentScale <= minScale)
        {
            scalingFactor = -scalingFactor;
            isWaiting = true;
        }

        ApplyCurrentScale();
    }

    private void ApplyCurrentScale() => transform.localScale = new Vector3(currentScale, currentScale, 1);
}
