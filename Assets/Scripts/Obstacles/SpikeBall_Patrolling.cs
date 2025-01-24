using UnityEngine;

public class SpikeBall_Patrolling : MonoBehaviour
{
    public float rotationAngle = 90.0f;
    float patrolSpeed = 2.0f;

    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;

    void Start() => SetPatrolPoints();

    void Update()
    {
        if (GameManager.isPlayerDead == true) return;
        
        RotateSpikeBall();
        PatrolSpikeBall();
    }

    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);

        if (transform.position == targetPoint)
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
    }
}