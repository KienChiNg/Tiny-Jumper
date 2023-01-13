using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip fallSound;
    public AudioClip gameOverSound;
}
