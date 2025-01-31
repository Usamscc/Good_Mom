// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public enum AuidoType
// {
//    Music,Sound;
// }
// [System.Serializable]
// public class Sound
// {
//    public string name;
//    public AudioType audioType;
//    public AudioClip Clip;
//
//
//    [HideInInspector]
//    public AudioSource Source;
//
//    public float volume = 1;
//    public float pitch = 1;
//
//    public bool loop = false;
//    public bool playOnStart = false;
//
// }
// public class AudioManager : MonoBehaviour
// {
//    public static AudioManager instance;
//    public Sound[] sounds;
//
//    void Awake()
//    {
//       if (instance == null)
//          instance = this;
//       // DontDestroyOnLoad(this);
//    }
//
//
//    private void Start()
//    {
//       foreach (Sound s in sounds)
//       {
//          AudioSource source = gameObject.AddComponent<AudioSource>();
//          source.clip = s.Clip;
//          source.volume = s.volume;
//          source.pitch = s.pitch;
//          source.loop = s.loop;
//
//          s.Source = source;
//
//          if (s.playOnStart)
//             s.Source.Play();
//       }
//    }
//
//    public void Play()
//    {
//       
//    }
// }
