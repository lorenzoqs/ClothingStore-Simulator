using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stayDuration = 15f;
    [SerializeField] private Animator animator;

    private Vector3 targetPosition;
    private float stayTimer = 0f;
    private bool isLeaving = false;
    private bool hasSpentMoney = false;

    private void Update()
    {
        if (!isLeaving)
        {
            // Moving to target position
            float distance = Vector3.Distance(transform.position, targetPosition);
            if (distance > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                // Look at target
                transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
            }
            else
            {
                // Arrived at position
                stayTimer += Time.deltaTime;

                if (!hasSpentMoney && stayTimer > 2f)
                {
                    // Buy random item
                    ClothingItem[] items = FindObjectsOfType<ClothingItem>();
                    if (items.Length > 0)
                    {
                        ClothingItem item = items[Random.Range(0, items.Length)];
                        item.Interact();
                        hasSpentMoney = true;
                    }
                }

                if (stayTimer >= stayDuration)
                {
                    Leave();
                }
            }
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }

    private void Leave()
    {
        isLeaving = true;
        targetPosition = transform.position + Vector3.back * 10f;
        Destroy(gameObject, 15f);
    }
}