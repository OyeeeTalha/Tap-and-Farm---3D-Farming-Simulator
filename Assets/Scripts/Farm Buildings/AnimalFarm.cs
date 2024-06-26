using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(AnimalFarm))]
public class AnimalFarmEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AnimalFarm AnimalFarm = (AnimalFarm)target;

        EditorGUILayout.Space();

        if (GUILayout.Button("Sell Animal"))
        {
            AnimalFarm.SellAnimal();
        }
        if (GUILayout.Button("Buy Animal"))
        {
            AnimalFarm.BuyAnimal();
        }
    }
}




public class AnimalFarm : MonoBehaviour
{
    public GameObject AnimalPrefab;
    public Transform spawnPoint;
    public float WanderWidth = 10f;
    public float WanderLength = 10f;
    public int MaxAnimals = 10;
    public float wanderDelayMin = 1f;
    public float wanderDelayMax = 5f;
    public float AnimalSpeed = 2f;
    public int InitialAnimalCount = 5; // Number of initial chickens in the farm

    private int currentAnimalCount = 0;

    private void Start()
    {

        // Spawn initial chickens
        for (int i = 0; i < InitialAnimalCount; i++)
        {
            BuyAnimal();
        }
    }

    private void OnDrawGizmos()
    {
        // Draw gizmos to visualize the spawn area limits
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector3(WanderWidth, 0f, WanderLength));
    }

    public void SpawnAnimal()
    {
        // Check if maximum number of chickens has been reached
        if (currentAnimalCount >= MaxAnimals)
        {
            Debug.Log("Maximum number of chickens reached!");
            return;
        }

        // Instantiate a new chicken at a random position within the specified range around the spawn point
        Vector3 randomPosition = GetRandomPositionInSpawnArea();
        GameObject Animal = Instantiate(AnimalPrefab, randomPosition, Quaternion.identity);
        Animal.transform.SetParent(transform);

        // Configure chicken's movement
        AnimalMovement _animalMovement = Animal.GetComponent<AnimalMovement>();
        _animalMovement.Initialize(this, AnimalSpeed, wanderDelayMin, wanderDelayMax);

        // Increase the chicken count
        currentAnimalCount++;
    }

    public Vector3 GetRandomPositionInSpawnArea()
    {
        Vector3 randomPosition = spawnPoint.position;
        randomPosition += new Vector3(Random.Range(-(WanderWidth / 2f), (WanderWidth / 2f)), 0f, Random.Range(-(WanderLength / 2f), (WanderLength / 2f)));
        randomPosition.y = spawnPoint.position.y;

        return randomPosition;
    }

    public void BuyAnimal()
    {
        // Check if maximum number of chickens is reached
        if (currentAnimalCount >= MaxAnimals)
        {
            Debug.Log("Maximum number of chickens reached!");
            return;
        }

        // Spawn a new chicken
        SpawnAnimal();
    }

    public void SellAnimal()
    {
        if (currentAnimalCount <= 0)
        {
            Debug.Log("No chickens available to sell!");
            return;
        }

        // Find a random chicken and sell it
        AnimalMovement[] _animals = GetComponentsInChildren<AnimalMovement>();
        int randomIndex = Random.Range(0, _animals.Length);
        Destroy(_animals[randomIndex].gameObject);

        // Decrease the chicken count
        currentAnimalCount--;
    }
}
