using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// HOW WE GET THOSE THINGS TO HAPPEN

public class QuestManager : MonoBehaviour
{
    public Text InteractText;
    private string text;
    public int questNumber = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Quest")) 
        {
            switch(questNumber)
            {
                case 1:
                    Debug.Log("mission 1");
                    text = "Press E to harvest.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest1();
                        questNumber++;
                        text = "";
                    }
                    break;
                case 2:
                    Debug.Log("Mission 2");
                    text = "Press E to harvest.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest2();
                        questNumber++;
                        text = "";
                    }
                    break;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Quest"))
        {
            text = "";
        }
    }

    private void Update()
    {
        InteractText.GetComponent<Text>().text = text;
    }
}
