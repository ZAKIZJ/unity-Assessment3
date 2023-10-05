using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip introMusic;
    public AudioClip normalGhostMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayIntroMusic();
    }

    void PlayIntroMusic()
    {
        audioSource.clip = introMusic;
        audioSource.Play();
        Invoke("PlayNormalGhostMusic", introMusic.length);
    }

    void PlayNormalGhostMusic()
    {
        audioSource.clip = normalGhostMusic;
        audioSource.Play();
    }
}
