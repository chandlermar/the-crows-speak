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
    public AudioClip windSounds;

    [Header("House Background Sounds")]
    public AudioSource HouseAmbienceSource;
    public AudioClip houseAmbience;

    [SerializeField] AudioSource FootstepSounds;
    public AudioClip[] grassSounds;
    public AudioClip[] stoneSounds;

    public AudioSource textSource;

    [SerializeField] AudioSource DiegeticSound;
    public AudioClip doorSound;



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
    public void PlayFootstep(string sound)
    {
        if (moveScript.controller.isGrounded)
        {
            if (sound == "grass")
            {
                FootstepSounds.volume = Random.Range(0.1f, 0.3f);
                FootstepSounds.pitch = Random.Range(0.5f, 1f);
                FootstepSounds.PlayOneShot(grassSounds[Random.Range(0, grassSounds.Length)]);
            }
            else if (sound == "stone")
            {
                FootstepSounds.volume = Random.Range(0.1f, 0.3f);
                FootstepSounds.pitch = Random.Range(0.5f, 1f);
                FootstepSounds.PlayOneShot(stoneSounds[Random.Range(0, stoneSounds.Length)]);
            }
        }
    }

    public void PlayBirds()
    {
        DaytimeBackgroundSource.volume = 0.3f;
        DaytimeBackgroundSource.loop = true;
        DaytimeBackgroundSource.PlayOneShot(windSounds);
    }

    public void PlayDoor()
    {
        DiegeticSound.PlayOneShot(doorSound);
    }

}