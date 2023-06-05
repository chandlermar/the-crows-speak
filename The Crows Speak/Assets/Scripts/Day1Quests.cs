using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ALL THE THINGS THAT ARE GOING TO HAPPEN


public class Day1Quests : MonoBehaviour
{
    public GameObject tomatoLeft;
    public GameObject tomatoRight;
    public GameObject cabbageLeft;
    public GameObject cabbageRight;

    public GameObject tomatoGroup;
    public GameObject cabbageGroup;

    public static Day1Quests inst;
    private void Awake()
    {
        inst = this;
    }

    public void Quest1()
    {
        tomatoLeft.SetActive(false);
    }

    public void Quest2()
    {
        tomatoRight.SetActive(false);
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
}
