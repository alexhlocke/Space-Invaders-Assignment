using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

//Taken from my pong assignment (following loosely a brackeys tutorial)
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake() {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {
        playSound("bg");
    }

    public void resetPitch(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = 1f;
    }

    public void pitchUp(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.pitch < 1.26f)
            s.source.pitch += 0.007f;
    } 

    public void playSound(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
