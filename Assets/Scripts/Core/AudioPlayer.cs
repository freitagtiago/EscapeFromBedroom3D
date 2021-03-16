using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;
    AudioSource audioSource;
    [SerializeField] AudioClip[] musics;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusic(0);
    }

    public void PlayMusic(int musicIndex)
    {
        audioSource.clip = musics[musicIndex];
        audioSource.Play();
    }
}
