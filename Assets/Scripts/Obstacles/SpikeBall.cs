using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public float rotationAngle = 90.0f;

    void Update()
    {
        if (GameManager.isPlayerDead == true) return;

        RotateSpikeBall();
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
}