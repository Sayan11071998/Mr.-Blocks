using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public float speed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        getInput();
        MovePlayer();
    }

    private void getInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log($"Horizontal: {horizontalInput}, Vertical: {verticalInput}");
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 moveDelta = moveDirection.normalized * speed * Time.deltaTime;
        transform.position += moveDelta;
    }
}