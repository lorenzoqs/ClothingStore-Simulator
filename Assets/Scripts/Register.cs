using UnityEngine;

public class Register : MonoBehaviour, IInteractable
{
    [SerializeField] private float totalInRegister = 0f;
    [SerializeField] private Animator registerAnimator;

    private void Start()
    {
        totalInRegister = 0f;
    }

    public void Interact()
    {
        Debug.Log($"💰 Register checked: ${totalInRegister}");
        if (registerAnimator != null)
        {
            registerAnimator.SetTrigger("Open");
        }
    }

    public void AddToRegister(float amount)
    {
        totalInRegister += amount;
    }

    public float GetTotal() => totalInRegister;
}
