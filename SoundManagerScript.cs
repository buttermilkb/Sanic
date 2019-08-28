using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerJumpSound, playerHitSound, coinCollectSound;
    static AudioSource audioSrc;


    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip> ("jump");
        playerHitSound = Resources.Load<AudioClip>("oof");
        coinCollectSound = Resources.Load<AudioClip> ("coinCollect");

        audioSrc = GetComponent<AudioSource> ();
    }


    void Update()
    {

    }

        public static void PlaySound (string clip)
        {
            switch (clip)
            {
                case "jump":
                    audioSrc.PlayOneShot(playerJumpSound);
                    break;
                case "oof":
                    audioSrc.PlayOneShot(playerHitSound);
                    break;
                case "coinCollect":
                    audioSrc.PlayOneShot(coinCollectSound);
                    break;
            }
        }
    }
