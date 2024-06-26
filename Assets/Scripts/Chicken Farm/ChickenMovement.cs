using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    private AnimalFarm AnimalFarm;
    private float movementSpeed;
    private float wanderDelayMin;
    private float wanderDelayMax;
    private float wanderDelay;
    private Vector3 wanderTarget;

    [SerializeField] private float wanderThreshold = 0.1f;

    private void Update()
    {
        if (wanderDelay <= 0f)
        {
            // Generate a new random target position within the spawn area
            wanderTarget = AnimalFarm.GetRandomPositionInSpawnArea();
            float distance = Vector3.Distance(transform.position, wanderTarget);
            wanderDelay = Random.Range(wanderDelayMin, wanderDelayMax) + distance / movementSpeed;

            // Move towards the new target
            transform.LookAt(wanderTarget);
        }

        // Move towards the target position
        float distanceToTarget = Vector3.Distance(transform.position, wanderTarget);
        if (distanceToTarget > wanderThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, wanderTarget, movementSpeed * Time.deltaTime);
        }

        wanderDelay -= Time.deltaTime;
    }

    public void Initialize(AnimalFarm farm, float speed, float delayMin, float delayMax)
    {
        AnimalFarm = farm;
        movementSpeed = speed;
        wanderDelayMin = delayMin;
        wanderDelayMax = delayMax;
        wanderDelay = 0f;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(wanderTarget, new Vector3(.1f, .1f, .1f));
    }
}
