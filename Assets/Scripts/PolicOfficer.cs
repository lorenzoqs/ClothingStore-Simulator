using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float inspectionDuration = 20f;

    private Vector3 targetPosition;
    private float inspectionTimer = 0f;
    private bool isInspecting = false;

    private void Update()
    {
        if (isInspecting)
        {
            inspectionTimer += Time.deltaTime;
            if (inspectionTimer >= inspectionDuration)
            {
                Leave();
            }
        }
        else
        {
            // Move to target
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void SetInspectionMode(bool inspecting)
    {
        isInspecting = inspecting;
        inspectionTimer = 0f;
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }

    private void Leave()
    {
        targetPosition = transform.position + Vector3.back * 15f;
        Destroy(gameObject, 10f);
    }
}
