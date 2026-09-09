using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
{
    [SerializeField] private float growthTime = 60f; // Seconds to grow
    [SerializeField] private float harvestPrice = 200f;
    [SerializeField] private MeshRenderer plantMesh;
    [SerializeField] private Material seedMaterial;
    [SerializeField] private Material grownMaterial;

    private float growthTimer = 0f;
    private bool isGrown = false;
    private bool hasBeenHarvested = false;

    private void Update()
    {
        if (!isGrown && !hasBeenHarvested)
        {
            growthTimer += Time.deltaTime;

            // Visual growth progression
            float growthProgress = growthTimer / growthTime;
            transform.localScale = Vector3.one * (0.5f + growthProgress * 0.5f);

            if (growthTimer >= growthTime)
            {
                isGrown = true;
                plantMesh.material = grownMaterial;
                Debug.Log("🌱 Plant is ready to harvest!");
            }
        }
    }

    public void Interact()
    {
        if (isGrown && !hasBeenHarvested)
        {
            Harvest();
        }
        else if (!isGrown)
        {
            Debug.Log("⏳ Plant still growing...");
        }
    }

    private void Harvest()
    {
        hasBeenHarvested = true;
        isGrown = false;
        GameManager.Instance.AddMoney(harvestPrice);
        GameManager.Instance.AddPlantHarvest();
        Debug.Log($"🌾 Harvested plant! +${harvestPrice}");
        
        // Reset for new growth
        Invoke("ResetGrowth", 5f);
    }

    private void ResetGrowth()
    {
        growthTimer = 0f;
        hasBeenHarvested = false;
        plantMesh.material = seedMaterial;
        transform.localScale = Vector3.one * 0.5f;
        Debug.Log("🌱 New seed planted!");
    }
}