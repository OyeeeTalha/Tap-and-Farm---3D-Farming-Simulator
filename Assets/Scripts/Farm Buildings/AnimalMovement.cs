using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public AnimalFarm _AnimalFarm;
    private float movementSpeed;
    private float wanderDelayMin;
    private float wanderDelayMax;
    private float wanderDelay;
    private Vector3 wanderTarget;

    private AnimalAnimationController _animalAnimationController;

    [SerializeField] private float wanderThreshold = 0.1f;

    private void Update()
    {
        if (wanderDelay <= 0f)
        {
            // Generate a new random target position within the spawn area
            //_AnimalFarm = FindObjectOfType<AnimalFarm>();
            wanderTarget = _AnimalFarm.GetRandomPositionInSpawnArea();
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
            this.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else if(distanceToTarget < wanderThreshold)
            this.GetComponent<Animator>().SetBool("isWalking", false);

        wanderDelay -= Time.deltaTime;
    }

    public void Initialize(AnimalFarm farm, float speed, float delayMin, float delayMax)
    {
        _AnimalFarm = farm;
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
