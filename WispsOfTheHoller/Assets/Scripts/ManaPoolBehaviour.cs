using UnityEngine;

public class ManaPoolBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _manaValue = 50;
    public int ManaValue { get => _manaValue; }
    [SerializeField]
    private AudioClip _restoreSound;
    public AudioClip RestoreSound { get => _restoreSound; }
}
