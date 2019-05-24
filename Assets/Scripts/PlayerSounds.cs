using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Step()
    {
        AudioClip clip = GetRandomClip();
        AudioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
