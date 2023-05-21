using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{ 
    private enum MissionState
    {
        Mission1,
        Mission2,
        // Add more mission states as needed

    }

    private enum Mission1Substates
    {
        mission1sub1, //pick up pail
        mission1sub2, //water tomatos
        mission1sub3, //pick up tomato bin
        mission1sub4, //drop tomatos inside
        mission1sub5, //sleep!
        // Add more mission states as needed
    }

    private MissionState currentMissionState;

    [Header("Mission1 Checks")]
    private Mission1Substates mission1activesub;

    public float fireRate = 1f;
    private float fireCooldown = 0f;
    public GameObject weapon;
    float maxRaycastDistance = 100f;

    [Header("Day1 Assets")]
    public GameObject pailToInherit;
    public GameObject pailStatic;
    public GameObject bucketStatic;
    public GameObject bucketToInherit;
    public GameObject bucketHouseStatic;

    [Header("Equipped Assets")]
    public GameObject inventory;

    private void Update()
    {
        if (inventory != null)
        {
            if (inventory.CompareTag("Gun"))
            {
                // Check if the fire cooldown has ended
                if (fireCooldown <= 0f)
                {
                    // Check for player input to fire
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Call the Fire method
                        Fire();
                    }
                }
                else
                {
                    // Reduce the fire cooldown timer
                    fireCooldown -= Time.deltaTime;
                }
            }
        }


        switch (currentMissionState)
        {
            case MissionState.Mission1:
                
                Mission1();
                break;
            case MissionState.Mission2:
                Mission2();
                break;
                // Handle other mission states here
        }


    }

    private void Start()
    {
        inventory = null;
        currentMissionState = MissionState.Mission1;
        mission1activesub = Mission1Substates.mission1sub1;
    }

    public void Mission1()
    {
        
        switch(mission1activesub)
        {
           
            case Mission1Substates.mission1sub1:
                if (Input.GetMouseButtonDown(1))
                {
                    // Create a raycast from the camera's position and forward direction
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    // Perform the raycast
                    if (Physics.Raycast(ray, out hit, maxRaycastDistance))
                    {
                        // Check if the raycast hit something
                        if (hit.collider != null)
                        {

                            if (hit.collider.CompareTag("Pail"))
                            {
                                // Access the hit object or do something with the hit information
                                GameObject hitObject = hit.collider.gameObject;
                                inventory = hitObject;
                                hitObject.SetActive(false);
                                pailToInherit.SetActive(true);
                                mission1activesub = Mission1Substates.mission1sub2;
                            }
                        }
                    }
                }
                break;


            case Mission1Substates.mission1sub2:
                if (Input.GetMouseButtonDown(0))
                {
                    // Create a raycast from the camera's position and forward direction
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    // Perform the raycast
                    if (Physics.Raycast(ray, out hit, maxRaycastDistance))
                    {
                        // Check if the raycast hit something
                        if (hit.collider != null)
                        {
                            if (hit.collider.CompareTag("Tomato"))
                            {
                                Debug.Log("hit tomato");
                                // Access the hit object or do something with the hit information
                                GameObject hitObject = hit.collider.gameObject;
                                Debug.Log(hitObject.name);
                                inventory = null;
                                pailStatic.SetActive(true);
                                pailToInherit.SetActive(false);
                                UIMgr.inst.sub1.color = Color.green;
                                mission1activesub = Mission1Substates.mission1sub3;
                            }
                        }
                    }
                }
                break;

                case Mission1Substates.mission1sub3:
                    if (Input.GetMouseButtonDown(1))
                    {
                        // Create a raycast from the camera's position and forward direction
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;

                        // Perform the raycast
                        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
                        {
                            // Check if the raycast hit something
                            if (hit.collider != null)
                            {

                                if (hit.collider.CompareTag("Bucket"))
                                {
                                    // Access the hit object or do something with the hit information
                                    GameObject hitObject = hit.collider.gameObject;
                                    inventory = hitObject;
                                    hitObject.SetActive(false);
                                    bucketToInherit.SetActive(true);
                                    mission1activesub = Mission1Substates.mission1sub4;
                                }
                            }
                        }
                    }
                break;

                case Mission1Substates.mission1sub4:
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Create a raycast from the camera's position and forward direction
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;

                        // Perform the raycast
                        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
                        {
                            // Check if the raycast hit something
                            if (hit.collider != null)
                            {
                                if (hit.collider.CompareTag("BucketTarget"))
                                {
                                 //Debug.Log("hit target");
                                 // Access the hit object or do something with the hit information
                                 //GameObject hitObject = hit.collider.gameObject;
                                 //Debug.Log(hitObject.name);
                                 inventory = null;
                                 bucketHouseStatic.SetActive(true);
                                 bucketToInherit.SetActive(false);
                                 UIMgr.inst.sub2.color = Color.green;
                                 mission1activesub = Mission1Substates.mission1sub5;
                             }
                            }
                        }
                    }
                    break;



        }
    }

    public void Mission2()
    {

    }
    private void Fire()
    {
        Debug.Log("Fired");
        // Reset the fire cooldown timer
        fireCooldown = 1f / fireRate;

        // Create a raycast from the camera's position and forward direction
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
        {
            // Check if the raycast hit something
            if (hit.collider != null)
            {
                
                if (hit.collider.CompareTag("lb_bird"))
                {
                    // Access the hit object or do something with the hit information
                    GameObject hitObject = hit.collider.gameObject;

                    lb_Bird birdScript = hitObject.GetComponent<lb_Bird>();
                    Debug.Log("Hit " + hitObject.name);
                    //Debug.Log(hit.name)
                    // Example: Destroy the hit object
                    birdScript.KillBird();
                    //Debug.Log("Hit2");
                }
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * maxRaycastDistance, Color.red);
       
    }
    
}
