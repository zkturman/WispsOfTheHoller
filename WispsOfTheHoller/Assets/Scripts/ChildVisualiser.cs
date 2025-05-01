using UnityEngine;

public class ChildVisualiser : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawSphere(transform.GetChild(i).position, 5);
        }
    }
}
