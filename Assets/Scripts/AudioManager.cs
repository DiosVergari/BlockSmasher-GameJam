using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource AudioSource;

    public AudioClip[] Good;
    public AudioClip[] Bad;
    public AudioClip Win;

    private void Awake()
    {
        Instance = this;

        AudioSource = GetComponent<AudioSource>();
    }

    public void GoodSFX()
    {
        sbyte rand = (sbyte) Random.Range(0, Good.Length);

        AudioSource.PlayOneShot(Good[rand]);
    }

    public void BadSFX()
    {
        sbyte rand = (sbyte)Random.Range(0, Bad.Length);

        AudioSource.PlayOneShot(Bad[rand]);
    }

    public void WinSFX()
    {
        AudioSource.PlayOneShot(Win);
    }

}
