using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFootstepSound : MonoBehaviour
{
    public static ChangeFootstepSound inst;

    public string sound = "grass";

    // Start is called before the first frame update
    void Start()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            sound = "stone";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            sound = "grass";
        }
    }
}