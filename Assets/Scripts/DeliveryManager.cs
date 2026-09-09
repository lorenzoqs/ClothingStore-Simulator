using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private float deliveryPrice = 150f;
    [SerializeField] private float deliveryTime = 20f;
    [SerializeField] private Transform deliveryStartPoint;

    private bool isDelivering = false;
    private float deliveryTimer = 0f;

    public void StartDelivery()
    {
        if (!isDelivering)
        {
            isDelivering = true;
            deliveryTimer = 0f;
            Debug.Log("🛹 Delivery started! Use skateboard (hold R)");
        }
    }

    private void Update()
    {
        if (isDelivering)
        {
            deliveryTimer += Time.deltaTime;

            if (deliveryTimer >= deliveryTime)
            {
                CompleteDelivery();
            }
        }
    }

    private void CompleteDelivery()
    {
        isDelivering = false;
        GameManager.Instance.AddMoney(deliveryPrice);
        GameManager.Instance.AddDelivery();
        Debug.Log($"✅ Delivery completed! +${deliveryPrice}");
    }

    public bool IsDelivering() => isDelivering;
    public float GetDeliveryProgress() => isDelivering ? deliveryTimer / deliveryTime : 0f;
}