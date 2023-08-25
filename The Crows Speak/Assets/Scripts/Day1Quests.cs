using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//ALL THE THINGS THAT ARE GOING TO HAPPEN


public class Day1Quests : MonoBehaviour
{
    public bool isNight = false;

    public Light Sun;

    public GameObject BirdController;

    //Active -> Inactive
    [Header("Day 1")]
    public GameObject tomatoLeft;
    public GameObject tomatoRight;
    public GameObject cabbageLeft;
    public GameObject cabbageRight;
    public GameObject day1Crows;

    //Inactive -> Active
    public GameObject tomatoGroup;
    public GameObject cabbageGroup;
    public GameObject scarecrow;
    public Image sleep;

    [Header("Day 2")]
    //public GameObject signCrow1;
    //public GameObject signCrow2;
    public GameObject scatteredTomatoes;
    public GameObject scatteredCabbages;
    public GameObject wateringCan;
    public GameObject playerWateringCan;

    [Header("Night 1")]
    public GameObject NightEyes;
    public GameObject Pentagram;


    public static Day1Quests inst;
    private void Awake()
    {
        inst = this;
    }

    public void Night1Prep()
    {
        Sun.intensity = 10f;
        NightEyes.SetActive(true);
        Pentagram.SetActive(true);
        StartCoroutine(MoveChildrenTowardsPlayer());
    }

    public void Day1Cleanup()
    {
        //Object Cleanup from day1
        tomatoLeft.SetActive(true);
        tomatoLeft.transform.localScale = new Vector3(1f, 0.3f, 1f);
        tomatoRight.SetActive(true);
        tomatoRight.transform.localScale = new Vector3(1f, 0.3f, 1f);
        cabbageLeft.SetActive(true);
        cabbageLeft.transform.localScale = new Vector3(1f, 0.3f, 1f);
        cabbageRight.SetActive(true);
        cabbageRight.transform.localScale = new Vector3(1f, 0.3f, 1f);
        day1Crows.SetActive(false);
        scarecrow.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void Day2Prep()
    {
        //Object Prep for day2
        scatteredTomatoes.SetActive(true);
        scatteredCabbages.SetActive(true);
        wateringCan.SetActive(true);
        BirdController.GetComponent<lb_BirdController>().idealNumberOfBirds = 5;
    }

    public void Day2Cleanup()
    {
        BirdController.GetComponent<lb_BirdController>().idealNumberOfBirds = 0;
        BirdController.GetComponent<lb_BirdController>().maximumNumberOfBirds = 0;
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
        scarecrow.SetActive(true);
        scarecrow.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    
    public void Quest8()
    {
        sleep.GetComponent<Animation>().Play("FadeOut");
        AudioMgr.inst.PlayDoor();
        //sleep.GetComponent<Animation>().Play("FadeIn"); || FADE BACK IN
        //AudioMgr.inst.PlayDoor();

        Day1Cleanup();
        Day2Prep();

        StopAll();
        Invoke("WakeUp", 5);
    }
    public void Quest9()
    {
        scatteredTomatoes.SetActive(false);
    }

    public void Quest10()
    {

    }

    public void Quest11()
    {
        scatteredCabbages.SetActive(false);
    }

    public void Quest12()
    {

    }

    public void Quest13()
    {
        wateringCan.SetActive(false);
        playerWateringCan.SetActive(true);
    }

    public void Quest14()
    {
        tomatoLeft.transform.localScale = new Vector3(1f, 1f, 1f);
        tomatoRight.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void Quest15()
    {
        cabbageLeft.transform.localScale = new Vector3(1f, 1f, 1f);
        cabbageRight.transform.localScale = new Vector3(1f, 1f, 1f);
        playerWateringCan.SetActive(false);
    }

    public void Quest16()
    {
        scarecrow.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void Quest17()
    {
        sleep.GetComponent<Animation>().Play("FadeOut");
        AudioMgr.inst.PlayDoor();
        //sleep.GetComponent<Animation>().Play("FadeIn"); || FADE BACK IN
        //AudioMgr.inst.PlayDoor();
        Day2Cleanup();
        Night1Prep();
        StopAll();
        Invoke("WakeUp", 5);
    }

    public void Quest18()
    {
        
    }


    /***   ***/

    private IEnumerator MoveChildrenTowardsPlayer()
    {
        while (true)
        {
            Transform[] nightEyesChildren = NightEyes.GetComponentsInChildren<Transform>();
            // Loop through all child transforms
            foreach (Transform child in nightEyesChildren)
            {
                Vector3 targetPosition = PlayerMgr.inst.playerBody.position; // Player's position as the target
                Vector3 newPosition = Vector3.MoveTowards(child.position, targetPosition, Time.deltaTime * 6);
                child.position = newPosition;
            }

            yield return null; // Wait for the next frame
        }
    }
} 