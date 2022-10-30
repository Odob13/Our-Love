using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    public AudioClip[] Clips;
    public AudioSource Source;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private AudioClip GetRandomClip()
    {
        return Clips[Random.Range(0, Clips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if(!Source.isPlaying)
        {
            Source.clip = GetRandomClip();
            Source.Play();
        }
    }
}
