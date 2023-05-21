using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMgr : MonoBehaviour
{
    CharacterControllerMovement moveScript;

    public static AudioMgr inst;

    [HideInInspector]
    public string sceneName;

    [Header("Daytime Background Sounds")]
    public AudioSource DaytimeBackgroundSource;
    public AudioClip birdSounds;

    [Header("House Background Sounds")]
    public AudioSource HouseAmbienceSource;
    public AudioClip houseAmbience;

    [SerializeField] AudioSource FootstepSounds;
    public AudioClip[] grassSounds;

    public AudioSource textSource;

    [SerializeField] AudioSource DiegeticSound;



    // Start is called before the first frame update
    private void Awake()
    {
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMovement>();
        inst = this;
    }

    private void Start()
    {
        HouseAmbienceSource = GetComponent<AudioSource>();
        //DaytimeBackgroundSource.volume = .2f;
        DaytimeBackgroundSource.Play();
        PlayBirds();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayTextSound(AudioClip sound)
    {
        textSource.PlayOneShot(sound);
    }
    public void PlayFootstep()
    {
        if (moveScript.controller.isGrounded)
        {
            FootstepSounds.volume = Random.Range(0.1f, 0.3f);
            FootstepSounds.pitch = Random.Range(0.5f, 1f);
            FootstepSounds.PlayOneShot(grassSounds[Random.Range(0, grassSounds.Length)]);
        }
    }

    void PlayBirds()
    {
        DaytimeBackgroundSource.volume = 0.3f;
        DaytimeBackgroundSource.loop = true;
        DaytimeBackgroundSource.PlayOneShot(birdSounds);
    }

    

}