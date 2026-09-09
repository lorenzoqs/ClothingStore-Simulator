using UnityEngine;
using TMPro;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform doorPivot;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float closeAngle = 0f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private TextMeshProUGUI interactText;

    private bool isClosed = true;
    private bool isMoving = false;
    private float targetAngle;

    public bool IsClosed => isClosed;

    private void Start()
    {
        targetAngle = closeAngle;
    }

    private void Update()
    {
        if (isMoving)
        {
            float currentAngle = doorPivot.localEulerAngles.y;
            
            // Normalize angle
            if (currentAngle > 180) currentAngle -= 360;
            if (targetAngle > 180) targetAngle -= 360;

            if (Mathf.Abs(currentAngle - targetAngle) > 0.1f)
            {
                float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
                doorPivot.localEulerAngles = new Vector3(0, newAngle, 0);
            }
            else
            {
                doorPivot.localEulerAngles = new Vector3(0, targetAngle, 0);
                isMoving = false;
            }
        }

        UpdateInteractText();
    }

    public void Interact()
    {
        if (!isMoving)
        {
            isClosed = !isClosed;
            targetAngle = isClosed ? closeAngle : openAngle;
            isMoving = true;
            Debug.Log(isClosed ? "🚪 Door CLOSED" : "🚪 Door OPENED");
        }
    }

    private void UpdateInteractText()
    {
        if (interactText != null)
        {
            interactText.text = isClosed ? "Press E: Open Door" : "Press E: Close Door";
        }
    }
}