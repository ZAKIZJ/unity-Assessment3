using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public float speed = 5f;  // 移动速度
    public AudioClip movingAudioClip;  // 移动时的音效
    private Vector3 direction;  // 移动方向
    private AudioSource audioSource;  // 音频源组件
    private Animator animator;  // 动画组件

    void Start()
    {
        // 初始化移动方向为静止
        direction = Vector3.zero;

        // 获取音频源和动画组件
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 重置所有动画状态
        animator.SetBool("PacStudent_Up", false);
        animator.SetBool("PacStudent_Down", false);
        animator.SetBool("PacStudent_Left", false);
        animator.SetBool("PacStudent_Right", false);

        // 检测按键并设置方向
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.up;
            animator.SetBool("PacStudent_Up", true);
            PlayAudio();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.down;
            animator.SetBool("PacStudent_Down", true);
            PlayAudio();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3.left;
            animator.SetBool("PacStudent_Left", true);
            PlayAudio();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3.right;
            animator.SetBool("PacStudent_Right", true);
            PlayAudio();
        }

        // 根据方向移动PacStudent
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void PlayAudio()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.clip = movingAudioClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
