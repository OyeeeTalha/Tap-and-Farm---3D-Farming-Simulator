using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobileInput;

public class CharacterController : MonoBehaviour
{
    public Camera mainCamera;
    public float movementSpeed = 5f;
    public float rotationSpeed = 10f;
    public Animator animator;

    private Rigidbody rb;

    

    [SerializeField] Joystick farmerJoystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (mainCamera == null)
        {
            // If the mainCamera reference is not set, use the main camera in the scene
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        float moveHorizontal = farmerJoystick.CurrentProcessedValue.x;
        float moveVertical = farmerJoystick.CurrentProcessedValue.y;

        // Get the forward and right vectors of the camera
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Remove the y component to ensure movement stays on the ground plane
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on camera facing
        Vector3 movementDirection = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        // Rotate the character towards the movement direction only if there is movement
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Apply movement to the character controller
        rb.velocity = movementDirection * movementSpeed;

        // Update the animator based on the movement speed
        if (animator != null)
        {
            float currentSpeed = rb.velocity.magnitude;
            bool isWalking = currentSpeed > 0.1f;
            animator.SetBool("Walk", isWalking);
        }
    }
}
