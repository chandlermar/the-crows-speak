using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// HOW WE GET THOSE THINGS TO HAPPEN

public class QuestManager : MonoBehaviour
{
    public Text InteractText;
    public Text MissionText;
    private string text;
    public int questNumber = 1;
    private void OnTriggerStay(Collider other)
    {
        
           switch(questNumber)
           {
            case 1:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Spam E to Harvest.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest1();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 2:
                    if (other.CompareTag("Quest" + questNumber.ToString()))
                    {
                        text = "Spam E to Harvest.";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Day1Quests.inst.Quest2();
                            questNumber++;
                            text = "";
                        }
                    }
                    break;

            case 3:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Deposit.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest3();
                        questNumber++;
                        text = "";
                    }
                }
                    break;
            case 4:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to harvest.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest4();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 5:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to harvest.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest5();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 6:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Deposit.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest6();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 7:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Sleep.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest7();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 8:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to plant tomatoes";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest8();
                        questNumber++;
                        text = "";
                    }
                }
                break;
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Quest" + questNumber.ToString()))
        {
            text = "";
        }
    }

    private void Update()
    {
        InteractText.GetComponent<Text>().text = text;

        switch (questNumber)
        {
            case 1:
                MissionText.text = "Harvest Tomatos";
                break;
            case 2:
                MissionText.text = "Harvest Tomatos";
                break;
            case 3:
                MissionText.text = "Deposit Tomatos";
                break;
            case 4:
                MissionText.text = "Harvest Cabbage";
                break;
            case 5:
                MissionText.text = "Harvest Cabbage";
                break;
            case 6:
                MissionText.text = "Deposit Cabbage";
                break;
            case 7:
                MissionText.text = "Go To Sleep";
                break;
        }    
    }
}
