using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI deliveryText;
    [SerializeField] private TextMeshProUGUI notificationText;

    private DeliveryManager deliveryManager;
    private float notificationTimer = 0f;

    private void Start()
    {
        deliveryManager = FindObjectOfType<DeliveryManager>();
    }

    private void Update()
    {
        UpdateMoneyDisplay();
        UpdateDeliveryDisplay();
        UpdateNotifications();
    }

    private void UpdateMoneyDisplay()
    {
        if (moneyText != null)
        {
            moneyText.text = $"💰 ${GameManager.Instance.GetMoney():F0}";
        }
    }

    private void UpdateDeliveryDisplay()
    {
        if (deliveryText != null && deliveryManager != null)
        {
            if (deliveryManager.IsDelivering())
            {
                float progress = deliveryManager.GetDeliveryProgress() * 100f;
                deliveryText.text = $"🛹 Delivery: {progress:F0}%";
            }
            else
            {
                deliveryText.text = "🛹 Ready for delivery (Press R)";
            }
        }
    }

    public void ShowNotification(string message, float duration = 3f)
    {
        if (notificationText != null)
        {
            notificationText.text = message;
            notificationTimer = duration;
        }
    }

    private void UpdateNotifications()
    {
        if (notificationTimer > 0)
        {
            notificationTimer -= Time.deltaTime;
            if (notificationTimer <= 0)
            {
                if (notificationText != null)
                    notificationText.text = "";
            }
        }
    }
}