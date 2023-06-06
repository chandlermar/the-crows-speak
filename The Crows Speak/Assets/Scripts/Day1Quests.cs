using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//ALL THE THINGS THAT ARE GOING TO HAPPEN


public class Day1Quests : MonoBehaviour
{
    public bool isNight = false;

    //Active -> Inactive
    [Header("Day 1")]
    public GameObject tomatoLeft;
    public GameObject tomatoRight;
    public GameObject cabbageLeft;
    public GameObject cabbageRight;

    //Inactive -> Active
    public GameObject tomatoGroup;
    public GameObject cabbageGroup;
    public Image sleep;

    public static Day1Quests inst;
    private void Awake()
    {
        inst = this;
    }

    private void StopAll()
    {
        AudioMgr.inst.DaytimeBackgroundSource.Stop();
    }
    private void WakeUp()
    {
        sleep.GetComponent<Animation>().Play("FadeIn");
        AudioMgr.inst.PlayDoor();
        if (!isNight)
        {
            AudioMgr.inst.PlayBirds();
        }
    }

    public void Quest1()
    {
        tomatoLeft.SetActive(false);
    }

    public void Quest2()
    {
        tomatoRight.SetActive(false);
        DialogueMgr.inst.ActivateTomatoDialogue();
    }

    public void Quest3()
    {
        tomatoGroup.SetActive(true);
    }
    public void Quest4()
    {
        cabbageLeft.SetActive(false);
    }
    public void Quest5()
    {
        cabbageRight.SetActive(false);
    }
    public void Quest6()
    {
        cabbageGroup.SetActive(true);
    }

    public void Quest7()
    {
        sleep.GetComponent<Animation>().Play("FadeOut");
        AudioMgr.inst.PlayDoor();
        //sleep.GetComponent<Animation>().Play("FadeIn"); || FADE BACK IN
        //AudioMgr.inst.PlayDoor();

        //Object Cleanup
        tomatoLeft.SetActive(true);
        tomatoRight.SetActive(true);
        cabbageLeft.SetActive(true);
        cabbageRight.SetActive(true);

        StopAll();
        Invoke("WakeUp", 5);
    }

    public void Quest8()
    {
        
    }
} 