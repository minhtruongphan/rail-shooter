using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 42.5f;   
    [Tooltip("In m")] [SerializeField] float xRange = 45f;
    [Tooltip("In m")] [SerializeField] float yMax = 14f;
    [Tooltip("In m")] [SerializeField] float yMin = -31f;

    [SerializeField] float positionPitchFactor = -0.75f; // make player rotate depend on localPosition.y
    [SerializeField] float controlPitchFactor = -20f; // make player rotate depend on ythrow

    [SerializeField] float positionYawFactor = 0.66f; // make player rotate depend on localPosition.x

    [SerializeField] float controlRollFactor = -25f; // make player rotate depend on xthrow

    float xThrow, yThrow; // player input

    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
        ProcessRotation();
       
    }

    private void VerticalMovement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = Speed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yMin, yMax); //Limit how the player can move on the screen vertially
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void HorizontalMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = Speed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //Limit how the player can move on the screen horizontally
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
        
    }
    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    

}
