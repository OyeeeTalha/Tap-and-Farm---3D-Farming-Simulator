using UnityEngine;

public class AnimalAnimationController : MonoBehaviour
{
    private Vector3 previousPosition;
    private Animator animator;

    private void Start()
    {
        // Initialize the previous position to the current position
        previousPosition = transform.position;

        // Get the Animator component attached to the animal GameObject
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Calculate the position delta
        Vector3 positionDelta = transform.position - previousPosition;

        // Check if the animal has any position delta (magnitude greater than zero)
        bool isWalking = positionDelta.magnitude > 0.01f;

        // Check if the animal is currently eating
        //Sbool isEating = GetComponent<Animal>().isEating; // Replace 'Animal' with your own script that manages eating behavior

        // Set the appropriate animator parameters based on the current state
        animator.SetBool("isWalking", isWalking);
        //animator.SetBool("isEating", isEating);

        // Update the previous position
        previousPosition = transform.position;
    }
}
