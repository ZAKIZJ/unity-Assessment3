using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public float speed = 5f;  // �ƶ��ٶ�
    public AudioClip movingAudioClip;  // �ƶ�ʱ����Ч
    private Vector3 direction;  // �ƶ�����
    private AudioSource audioSource;  // ��ƵԴ���
    private Animator animator;  // �������

    void Start()
    {
        // ��ʼ���ƶ�����Ϊ��ֹ
        direction = Vector3.zero;

        // ��ȡ��ƵԴ�Ͷ������
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �������ж���״̬
        animator.SetBool("PacStudent_Up", false);
        animator.SetBool("PacStudent_Down", false);
        animator.SetBool("PacStudent_Left", false);
        animator.SetBool("PacStudent_Right", false);

        // ��ⰴ�������÷���
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

        // ���ݷ����ƶ�PacStudent
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
