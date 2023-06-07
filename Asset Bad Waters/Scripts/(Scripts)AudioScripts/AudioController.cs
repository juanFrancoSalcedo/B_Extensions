using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using MyBox;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSourceComp;
    //public GameObject shotObj;
    [SerializeField] private RaceController raceControl;

    [Header("~~~~~Clips~~~~~~~")]

    [SerializeField] AudioClip musicFirst;
    [SerializeField] AudioClip musicSecond;
    [SerializeField] AudioClip musicSixth;


    void Start()
    {
        audioSourceComp = GetComponent<AudioSource>();
        raceControl.OnPlayerArrived += PlayerArriveMusic;
    }

    public void PlayerArriveMusic(int _positionPlayer)
    {
        if (_positionPlayer == 1)
        {
            audioSourceComp.clip = musicFirst;
            audioSourceComp.Play();
        }
        else if (_positionPlayer > 1 && _positionPlayer < 6)
        {
            audioSourceComp.clip = musicSecond;
            audioSourceComp.Play();
        }
        else if (_positionPlayer >= 6)
        {
            audioSourceComp.clip = musicSixth;
            audioSourceComp.Play();
        }
    }
}
