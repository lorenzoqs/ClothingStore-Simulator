using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 20f;
    [SerializeField] private Vector3[] storeLocations;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnCustomer();
            spawnTimer = 0f;
        }
    }

    private void SpawnCustomer()
    {
        if (spawnPoint == null || customerPrefab == null)
            return;

        GameObject customer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
        Customer customerScript = customer.GetComponent<Customer>();

        if (customerScript != null && storeLocations.Length > 0)
        {
            Vector3 randomLocation = storeLocations[Random.Range(0, storeLocations.Length)];
            customerScript.SetTargetPosition(randomLocation);
            Debug.Log("👤 Customer spawned!");
        }
    }
}