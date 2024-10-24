using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    GUN,
    DEATH,
    AMOGUS,
    NOAMMO,
    MAXAMMO,
    DAMAGED
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource SetAudioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetAudioSource = GetComponent<AudioSource>();
    }
    // PlaySound(Type, volume)
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.SetAudioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
}
