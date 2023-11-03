
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 targetPosition;
    private Vector2 endPosition;

    private float timeSinceStarted;
    private float timeStartedLerping;

    private Vector2 lastInput;
    private Vector2 currentInput;
    private AudioSource audioSource;
    public AudioClip movingAudioClip;
    public AudioClip eatingAudioClip;
    private Animator animator;
    public LayerMask obstacleLayer; // The layer that marks the obstacles
    private Vector2 previousPosition;
    
    public new ParticleSystem particleSystem; // Reference to the particle system for wall collision
    public AudioClip wallCollisionClip; // The audio clip that plays when colliding with a wall


    void Start()
    {
        targetPosition = transform.position;
        endPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();
        Move();
        UpdateAnimation();
    }

    private void GetInput()
    {
        Vector2 moveInput = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) moveInput = Vector2.up;
        if (Input.GetKey(KeyCode.A)) moveInput = Vector2.left;
        if (Input.GetKey(KeyCode.S)) moveInput = Vector2.down;
        if (Input.GetKey(KeyCode.D)) moveInput = Vector2.right;
        if (moveInput != Vector2.zero)
        {
            lastInput = moveInput;
        }
    }

    private void Move()
    {
        Vector2 originalPosition = transform.position;

        // If PacStudent is at the target position
        if ((Vector2)transform.position == targetPosition)
        {
            Vector2 input = lastInput != Vector2.zero ? lastInput : currentInput;
            // Check if the next position is walkable
            if (IsWalkable(targetPosition + input))
            {
                targetPosition += input;
                currentInput = input;
            }
            else
            {
                // If not walkable, trigger the collision effects
                TriggerCollisionEffects();
                // Move PacStudent back to the previous position
                targetPosition = previousPosition;
            }
        }

        // Continue moving towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

       
    }
    private void TriggerCollisionEffects()
    {
        // Play the wall collision sound effect
        PlayAudio(wallCollisionClip);
        // Trigger the particle effect at the position of PacStudent
        particleSystem.Play();
    }

    private void UpdateAnimation()
    {
        animator.SetBool("PacStudent_Up", currentInput == Vector2.up);
        animator.SetBool("PacStudent_Down", currentInput == Vector2.down);
        animator.SetBool("PacStudent_Left", currentInput == Vector2.left);
        animator.SetBool("PacStudent_Right", currentInput == Vector2.right);
    }

    private bool IsWalkable(Vector2 targetPosition)
    {
        
        // Check if the target position is walkable
        Collider2D collider = Physics2D.OverlapCircle(targetPosition, 0.1f, obstacleLayer);
        return collider == null;
    }

    private void PlayAudio(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is a cherry
        if (collision.gameObject.CompareTag("Cherry"))
        {
            HandleCherryCollision(collision.gameObject);
        }
    }
    private void HandleCherryCollision(GameObject cherry)
    {
        // Destroy the cherry object
        Destroy(cherry);
    }
}
