using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerContext playerContext;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out WispBehaviour behaviour))
        {
            behaviour.Collect();
        }
    }
}
