using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ALL THE THINGS THAT ARE GOING TO HAPPEN


public class Day1Quests : MonoBehaviour
{
    public GameObject tomatoLeft;
    public GameObject tomatoRight;

    public static Day1Quests inst;
    private void Awake()
    {
        inst = this;
    }

    public void Quest1()
    {
        Debug.Log("pre");
        tomatoLeft.transform.parent.gameObject.SetActive(false);
        Debug.Log("post");
    }

    public void Quest2()
    {
        tomatoRight.transform.parent.gameObject.SetActive(false);
    }
}
