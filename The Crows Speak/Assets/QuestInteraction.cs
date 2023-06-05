using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInteraction : MonoBehaviour
{

    public static QuestInteraction inst;

    public bool TomatoLeftActive = false;
    public bool TomatoRightActive = false;

    public bool CabbageLeftActive = false;
    public bool CabbageRightActive = false;

    private void Awake()
    {
        inst = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameMgr.inst.mission1activesub == GameMgr.Mission1Substates.mission1sub1)
        {
            if (other.CompareTag("TomatoLeft"))
            {
                // prompt text
                Debug.Log("Entered the tomatos yuihhh. E to interact.");
            }
            else if (other.CompareTag("TomatoRight"))
            {
                // prompt text
                Debug.Log("Entered the tomatos yuihhh. E to interact.");
            }
        }
        if (GameMgr.inst.mission1activesub == GameMgr.Mission1Substates.mission1sub2)
        {
            if (other.CompareTag("CabbageLeft"))
            {
                // prompt text
                Debug.Log("Entered the cabbage yuihhh. E to interact.");
            }
            else if (other.CompareTag("CabbageRight"))
            {
                // prompt text
                Debug.Log("Entered the caggage yuihhh. E to interact.");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (GameMgr.inst.mission1activesub == GameMgr.Mission1Substates.mission1sub1)
        {
            if (other.CompareTag("TomatoLeft"))
            {
                TomatoLeftActive = false;
                //text
            }
            else if (other.CompareTag("TomatoRight"))
            {
                TomatoRightActive = false;
                //text
            }
        }
        if (GameMgr.inst.mission1activesub == GameMgr.Mission1Substates.mission1sub2)
        {
            if (other.CompareTag("CabbageLeft"))
            {
                CabbageLeftActive = false;
                //text
            }
            else if (other.CompareTag("TomatoRight"))
            {
                CabbageRightActive = false;
                //text
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (GameMgr.inst.mission1activesub == GameMgr.Mission1Substates.mission1sub1)
        {
            if (other.CompareTag("TomatoLeft"))
            {
                TomatoLeftActive = true;
                //update
            }
            if (other.CompareTag("TomatoRight"))
            {
                TomatoRightActive = true;
                //update
            }
        }
        if (GameMgr.inst.mission1activesub == GameMgr.Mission1Substates.mission1sub2)
        {
            if (other.CompareTag("CabbageLeft"))
            {
                CabbageLeftActive = true;
            }
            else if (other.CompareTag("CabbageRight"))
            {
                CabbageLeftActive = true;
            }
        }

    }

}
