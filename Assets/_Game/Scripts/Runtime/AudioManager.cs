using System;
using UnityEngine;

public enum AudioType
{
   UI_Sound, Collision_Sound
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioType audioType;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    public float volume = 1f;
    //public float pitch = 1f;
    public bool loop = false;
    public bool playOnStart = false;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = s.clip;
            source.volume = s.volume;
           // source.pitch = s.pitch;
            source.loop = s.loop;

            s.source = source;

            if (s.playOnStart)
                s.source.Play();
        }
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound not found: " + soundName);
            return;
        }
        s.source.Play();
    }

    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound not found: " + soundName);
            return;
        }
        s.source.Stop();
    }
    public void Pause(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound not found: " + soundName);
            return;
        }
        s.source.Pause();
    }
}