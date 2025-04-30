using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerContext playerContext;
    private float _currentMana;

    private void Awake()
    {
        _currentMana = playerContext.Stats.BaseMana;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out WispBehaviour behaviour))
        {
            behaviour.Collect();
        }
    }

    public bool HasMana()
    {
        return _currentMana > 0;
    }

    public float RemainingManaPercent()
    {
        return _currentMana / playerContext.Stats.BaseMana;
    }

    public void RefillMana()
    {
        _currentMana = playerContext.Stats.BaseMana;
    }

    public void RefillMana(float refillAmount)
    {
        _currentMana += refillAmount;
    }

    public void UseMana(float manaCost)
    {
        _currentMana -= manaCost;
    }
}
