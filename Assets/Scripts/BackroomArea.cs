using UnityEngine;

public class BackroomArea : MonoBehaviour
{
    [SerializeField] private Plant[] plants;
    [SerializeField] private Door doorToStore;
    [SerializeField] private float harvestValue = 200f;

    private float totalHarvestedToday = 0f;

    private void Start()
    {
        plants = GetComponentsInChildren<Plant>();
    }

    public void CalculateDailyYield()
    {
        totalHarvestedToday = 0f;
        foreach (Plant plant in plants)
        {
            // Wird automatisch durch Plant.cs gehandhabt
        }
        Debug.Log($"🌾 Daily backroom yield: ${totalHarvestedToday}");
    }

    public float GetDoorStatus()
    {
        return doorToStore.IsClosed ? 0f : 1f; // 0 = sicher, 1 = offen (Risiko!)
    }
}
