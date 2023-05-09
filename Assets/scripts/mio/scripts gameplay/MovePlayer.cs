using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public cameracontrol shakecam;
    public ParticleSystem dust;
    public ParticleSystem dust2;
    public GameObject explosion;
    public Vector2 currentposition;
    public Vector2 positionofdeath;
    public int win;
    public bool died_thisRound;

    private float horizontal;
    private bool enSuelo;
    private Animator animator;
    [SerializeField] public float speed = 8f;
    [SerializeField] public float jumpingPower = 16f;
    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource deathsound;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentposition = transform.position;
        
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
            if (enSuelo)
            {
                playDust();
            }
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
            if (enSuelo)
            {
                playDust();
            }
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        enSuelo = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
        animator.SetBool("enSuelo", enSuelo);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("enSuelo", false);
            dust2.Play();
            jumpsound.Play();
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    { 
        return enSuelo = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));

    }

    public void playDust()
    {
        dust.gameObject.SetActive(true);
        dust.Play();
    }
    public void PowerUpVelocity()
    {
        shakecam.ShakeCamera(0.05f, 0.2f);
        speed = speed + 4f;
    }

    public void StopAllPowerUp()
    {
        speed = 14f;
        jumpingPower = 19f;
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Finish"))
        {
            win++;
            Debug.Log("I win this round");
        }

        if (collider2D.gameObject.CompareTag("Death"))
        {
            died_thisRound = true;
            transform.position = new Vector2(-989, -1);
        }

        if (collider2D.gameObject.CompareTag("Lava"))
        {
            positionofdeath = currentposition;
            GameObject particulasmuerte = Instantiate(explosion, positionofdeath, transform.rotation);
            deathsound.Play();
            shakecam.ShakeCamera(0.2f, 1f);
            transform.position = new Vector2(-1000, 0);
            Debug.Log("I died");

        }

        if (collider2D.gameObject.CompareTag("PowerUpVelocity"))
        {
            PowerUpVelocity();
            Invoke("StopAllPowerUp", 2f);
        }
    }

}