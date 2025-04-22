using UnityEngine;

public class PuzzleTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToAffect;
    [SerializeField]
    private bool isActivator = true;

    public void Solve()
    {
        for (int i = 0; i < objectsToAffect.Length; i++)
        {
            objectsToAffect[i].SetActive(isActivator);
        }
    }
}
