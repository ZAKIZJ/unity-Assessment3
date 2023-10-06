using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private Vector2 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        ResetAnimatorBooleans();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            
            direction = new Vector2(horizontal, vertical);
        }

        if (direction.x > 0)
        {
            animator.SetBool("PacStudent_Right", true);
        }
        else if (direction.x < 0)
        {
            animator.SetBool("PacStudent_Left", true);
        }
        else if (direction.y > 0)
        {
            animator.SetBool("PacStudent_Up", true);
        }
        else if (direction.y < 0)
        {
            animator.SetBool("PacStudent_Down", true);
        }
    }

    private void ResetAnimatorBooleans()
    {
        animator.SetBool("PacStudent_Right", false);
        animator.SetBool("PacStudent_Left", false);
        animator.SetBool("PacStudent_Up", false);
        animator.SetBool("PacStudent_Down", false);

    }

    public void Die()
    {
        animator.SetTrigger("Dead");
    }
}
