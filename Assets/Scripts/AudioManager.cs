using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource SFX;

    [Header("-------- Audio Clip --------")]
    public AudioClip hit;
    public AudioClip jump;
    public AudioClip landing;
    public AudioClip shot;

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
