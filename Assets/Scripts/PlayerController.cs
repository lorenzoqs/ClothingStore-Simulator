using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera mainCamera;

    private Vector3 moveDirection = Vector3.zero;
    private bool isHolding = false;
    private GameObject heldItem = null;

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
        HandleDelivery();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move relative to camera direction
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * vertical + right * horizontal).normalized * moveSpeed;

        // Rotate player to face movement direction
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 2f))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }

    private void HandleDelivery()
    {
        // Press R to ride skateboard (delivery mode)
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("🛹 Skateboard delivery mode activated!");
            moveSpeed = 8f; // Faster movement
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            moveSpeed = 5f;
        }
    }

    public bool IsHoldingItem() => isHolding;
    public void SetHoldingItem(GameObject item) 
    { 
        heldItem = item;
        isHolding = true;
    }

    public void ReleaseItem()
    {
        heldItem = null;
        isHolding = false;
    }
}