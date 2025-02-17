using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SoundManager soundManager;
    public LevelManager levelManager;
    public CameraShake cameraShake;

    private float horizontalInput, verticalInput;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();
        cameraShake = FindObjectOfType<CameraShake>();

        if (soundManager == null)
            Debug.Log("SoundManager not found in the Scene");
    }

    void Update() => getInput();

    private void FixedUpdate() => MovePlayer();

    private void getInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            StartCoroutine(PlayerDeathSequence());
    }

    private IEnumerator PlayerDeathSequence()
    {
        yield return cameraShake.Shake(0.5f, 0.3f);
        PlayerDied();
    }

    private void PlayerDied()
    {
        soundManager.PlayGameOverAudio();
        levelManager.onPlayerDeath();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
            LevelComplete();
    }

    private void LevelComplete()
    {
        soundManager.PlayLevelCompleteAudio();
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }
}