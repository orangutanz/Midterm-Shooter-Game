using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager mInstance;
    public AudioClip MonsterDie;
    public AudioClip WeaponSwap;


    public static AudioManager Get()
    {
        if (mInstance == null)
            mInstance = new AudioManager();
        return mInstance;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    public void PlayMonsterDieAudio(AudioSource source)
    {
        source.clip = MonsterDie;
        source.Play();
    }

    public void PlayWeaponSwapAudio(AudioSource source)
    {
        source.clip = WeaponSwap;
        source.Play();
    }
}
