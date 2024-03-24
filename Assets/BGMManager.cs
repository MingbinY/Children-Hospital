using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip normalMusic;
    public AudioClip scaryMusic;
    public AudioClip scarySFX;

    public AudioSource normalSource;
    public AudioSource scarySource;
    public AudioSource sfxSource;

    bool scared = false;

    private void Start()
    {
        scarySource.clip = scaryMusic;
        normalSource.clip = normalMusic;
        normalSource.Play();
    }

    private void Update()
    {
        if (GameManager.Instance.isScary && !scared)
        {
            sfxSource.PlayOneShot(scarySFX);
            scared = true;
            normalSource.Pause();
            scarySource.Play();
        }

        if (!GameManager.Instance.isScary && scared)
        {
            scared = false;
            scarySource.Pause();
            normalSource.Play();
        }
    }
}
