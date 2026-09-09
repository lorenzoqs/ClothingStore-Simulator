using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI timeText;

    private float money = 100000f;
    private int day = 1;
    private float currentTime = 8f; // 8:00 AM
    private float timeSpeed = 1f; // Simulation speed
    
    private int customersServed = 0;
    private int plantsHarvested = 0;
    private int deliveriesMade = 0;

    private bool policeArriving = false;
    private float policeArrivalTimer = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        UpdateTime();
        CheckForPoliceVisit();
        UpdateUI();
    }

    private void UpdateTime()
    {
        currentTime += Time.deltaTime * timeSpeed * 0.01f; // Adjust speed as needed

        if (currentTime >= 22f) // Close at 10 PM
        {
            currentTime = 8f;
            day++;
            policeArriving = false;
            policeArrivalTimer = 0f;
        }
    }

    private void CheckForPoliceVisit()
    {
        // Random police visits between 10 AM and 8 PM
        if (currentTime >= 10f && currentTime < 20f && !policeArriving)
        {
            if (Random.value < 0.02f) // ~2% chance per update
            {
                policeArriving = true;
                policeArrivalTimer = Random.Range(30f, 120f); // 30-120 seconds
                Debug.Log("⚠️ POLICE INCOMING!");
            }
        }

        if (policeArriving)
        {
            policeArrivalTimer -= Time.deltaTime;
            if (policeArrivalTimer <= 0f)
            {
                TriggerPoliceInspection();
                policeArriving = false;
            }
        }
    }

    private void TriggerPoliceInspection()
    {
        Door backroomDoor = FindObjectOfType<Door>();
        if (backroomDoor != null && !backroomDoor.IsClosed)
        {
            // FINE! Door was open during police visit
            float fine = 5000f;
            SubtractMoney(fine);
            Debug.Log($"🚔 POLICE FINE: ${fine}! Door was open!");
        }
        else
        {
            Debug.Log("✅ Police inspection passed! Door was closed.");
        }
    }

    public void AddMoney(float amount)
    {
        money += amount;
        Debug.Log($"💰 +${amount}. Total: ${money}");
    }

    public void SubtractMoney(float amount)
    {
        money -= amount;
        if (money < 0) money = 0;
        Debug.Log($"💸 -${amount}. Total: ${money}");
    }

    public float GetMoney() => money;

    public void AddCustomer()
    {
        customersServed++;
    }

    public void AddPlantHarvest()
    {
        plantsHarvested++;
    }

    public void AddDelivery()
    {
        deliveriesMade++;
    }

    private void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = $"${money:F0}";

        if (dayText != null)
            dayText.text = $"Day: {day}";

        if (timeText != null)
            timeText.text = $"Time: {Mathf.FloorToInt(currentTime):D2}:{((currentTime % 1f) * 60):D2}";
    }

    public float GetCurrentTime() => currentTime;
    public int GetDay() => day;
}