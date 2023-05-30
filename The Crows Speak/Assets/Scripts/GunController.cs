using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform playerCamera; // Reference to the player's camera
    public Transform gunModel; // Reference to the gun model

    // Update is called once per frame
    void Update()
    {
        // Get the vertical rotation of the player's camera
        float verticalRotation = playerCamera.localEulerAngles.x;

        // Apply the same rotation to the gun model
        gunModel.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
    }
}
