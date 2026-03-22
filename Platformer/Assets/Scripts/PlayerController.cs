using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D player;
    private bool isGrounded = false;
    private int health = 100;
    private int score = 0;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal player movement
        float moveInput = Input.GetAxis("Horizontal");
        player.linearVelocity = new Vector2(moveInput * moveSpeed, player.linearVelocity.y);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.TakeDamage(10);

            if (health <= 0)
            {
                GameManager.Instance.TriggerGameOver();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered: " + other.gameObject.name + " tag: " + other.tag);
        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.AddScore(10);
            CoinPoolManager.Instance.ReturnCoin(other.gameObject);
        }
    }
}
