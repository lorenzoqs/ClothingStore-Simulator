using UnityEngine;

public class ItemDisplay : MonoBehaviour, IInteractable
{
    [SerializeField] private float price = 50f;
    [SerializeField] private string itemName = "Clothing Item";
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private Renderer itemRenderer;

    private bool isPurchased = false;

    public void Interact()
    {
        if (!isPurchased)
        {
            Purchase();
        }
        else
        {
            Debug.Log($"⏳ {itemName} ist ausverkauft");
        }
    }

    private void Purchase()
    {
        isPurchased = true;
        GameManager.Instance.AddMoney(price);
        GameManager.Instance.AddCustomer();
        itemRenderer.enabled = false;
        
        Debug.Log($"✅ {itemName} verkauft für ${price}");
        
        // Restock nach 30 Sekunden
        Invoke(nameof(Restock), 30f);
    }

    private void Restock()
    {
        isPurchased = false;
        itemRenderer.enabled = true;
        Debug.Log($"📦 {itemName} wieder verfügbar");
    }

    public float GetPrice() => price;
    public string GetName() => itemName;
    public Sprite GetIcon() => itemIcon;
}
