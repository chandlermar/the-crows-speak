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
                    text = "Press E to Harvest.";
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
                    text = "Press E to Harvest.";
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
                    text = "Press E to Plant Scarecrow";
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
                    text = "Press E to Sleep.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest8();
                        questNumber++;
                        text = "";
                    }
                }
                break;
            case 9:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Grab Tomatoes.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest9();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 10:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Deposit.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest10();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 11:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Grab Cabbage.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest11();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 12:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Deposit.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest12();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 13:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Pick Up.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest13();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 14:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Water Crops.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest14();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 15:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Water Crops.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest15();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 16:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Repair.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest16();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 17:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Press E to Sleep.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest17();
                        questNumber++;
                        text = "";
                    }
                }
                break;

            case 18:
                if (other.CompareTag("Quest" + questNumber.ToString()))
                {
                    text = "Misc.";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Day1Quests.inst.Quest18();
                        questNumber++;
                        text = "";
                    }
                }
                break;
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
                MissionText.text = "Harvest Tomatoes";
                break;
            case 2:
                MissionText.text = "Harvest Tomatoes";
                break;
            case 3:
                MissionText.text = "Deposit Tomatoes";
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
                MissionText.text = "Plant Scarecrow";
                break;
            case 8:
                MissionText.text = "Go To Sleep";
                break;
            case 9:
                MissionText.text = "Grab Tomatos";
                break;
            case 10:
                MissionText.text = "Put Back Tomatoes";
                break;
            case 11:
                MissionText.text = "Grab Cabbages";
                break;
            case 12:
                MissionText.text = "Put Back Cabbages";
                break;
            case 13:
                MissionText.text = "Grab Watering Can";
                break;
            case 14:
                MissionText.text = "Water Tomatoes";
                break;
            case 15:
                MissionText.text = "Water Cabbages";
                break;
            case 16:
                MissionText.text = "Repair Scarecrows";
                break;
            case 17:
                MissionText.text = "Sleep";
                break;
            case 18:
                MissionText.text = "WIP";
                break;
        }    
    }
}
