using UnityEngine;

public class standingEnemy : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float distanceToPlayer = 10f;
    public float jumpCooldown = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 startingPosition;
    private bool isFacingRight = true;
    private bool isPlayerInRange = false;
    private float playerDirection;
    private Transform playerTransform;
    private float jumpTimer = 0f;

    public AudioSource hitNoise;
    public PlayerHealth player;

    private enum EnemyState {
        Idle,
        Moving,
        Jumping
    }

    private EnemyState currentState = EnemyState.Idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startingPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        CheckPlayerInRange();
        UpdateState();
        jumpTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (currentState == EnemyState.Moving)
        {
            Move();
        }
        else if (currentState == EnemyState.Jumping)
        {
            Jump();
        }
    }

    void CheckPlayerInRange()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < distanceToPlayer)
        {
            isPlayerInRange = true;
            playerDirection = Mathf.Sign(playerTransform.position.x - transform.position.x);
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    void UpdateState()
    {
        if (!isPlayerInRange)
        {
            currentState = EnemyState.Idle;
        }
        else
        {
            if (Mathf.Abs(transform.position.x - startingPosition.x) > 2f && jumpTimer <= 0f)
            {
                currentState = EnemyState.Jumping;
                jumpTimer = jumpCooldown;
            }
            else
            {
                currentState = EnemyState.Moving;
            }
        }
    }

    void Move()
    {
        if (isFacingRight && playerDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && playerDirection > 0)
        {
            Flip();
        }

        rb.velocity = new Vector2(speed * playerDirection, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(speed * playerDirection, jumpForce);
        currentState = EnemyState.Moving;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D (Collision2D other){
         if(other.gameObject.tag == "Player"){
            Debug.Log("collided!");
            hitNoise.Play();
            player.Damage(5);
            //SceneManager.LoadScene("Lose");
        }
    }
}
