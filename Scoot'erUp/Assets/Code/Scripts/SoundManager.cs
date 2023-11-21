using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip dirtSound, jumpSound, bounceySound, clickSound, closeMenu;
    [SerializeField] AudioSource audioSource;
    
    public void PlaySound (string clip)
    {
        switch(clip) {
          case "dirt":
            audioSource.PlayOneShot(dirtSound);
            break;
          case "jump":
            audioSource.PlayOneShot(jumpSound);
            break;
          case "bounce":
            audioSource.PlayOneShot(bounceySound);
            break;
          case "click":
            audioSource.PlayOneShot(clickSound);
            break;
          case "closeMenu":
            audioSource.PlayOneShot(closeMenu);
            break;
        }
    }
}
