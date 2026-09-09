using UnityEngine;

public class ClothingItem : MonoBehaviour, IInteractable
{
    [SerializeField] private float price = 50f;
    [SerializeField] private string itemName = "Clothing Item";
    [SerializeField] private Renderer itemRenderer;

    private bool isPurchased = false;
    private Transform shelfPosition;

    private void Start()
    {
        shelfPosition = transform.parent;
    }

    public void Interact()
    {
        if (!isPurchased)
        {
            Debug.Log($"📦 Customer bought: {itemName} for ${price}");
            GameManager.Instance.AddMoney(price);
            GameManager.Instance.AddCustomer();
            isPurchased = true;
            itemRenderer.enabled = false;
            Invoke("Restock", 30f); // Restock after 30 seconds
        }
    }

    private void Restock()
    {
        isPurchased = false;
        itemRenderer.enabled = true;
        Debug.Log($"📦 {itemName} restocked!");
    }

    public float GetPrice() => price;
    public string GetName() => itemName;
}