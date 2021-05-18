using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public AudioMixerGroup audioMixer;

    List<Sound> jumpSounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        jumpSounds = new List<Sound>();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = audioMixer;

            if (s.name == "Jump")
            {
                jumpSounds.Add(s); 
            }
        }
    }

    void Start()
    {
        Play("Music");
    }

    public void Play (string name)
    {
        Sound s;

        if (name == "Jump")
        {
            s = jumpSounds[UnityEngine.Random.Range(0, jumpSounds.Count)];
        }
        else
        {
            s = Array.Find(sounds, sound => sound.name == name);
        }
        
        if (s == null)
            return;

        s.source.Play();
    }
}
