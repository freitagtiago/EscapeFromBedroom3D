using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClipArray;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusic(0);
    }

    public void PlayMusic(int musicIndex)
    {
        _audioSource.clip = _audioClipArray[musicIndex];
        _audioSource.Play();
    }
}
