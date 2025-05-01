using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionTimer : MonoBehaviour
{
    [SerializeField]
    private float _collectionExpireTimeInSeconds = 15;
    private float _elapsedSecondsSinceReset = 0;
    [SerializeField]
    private AudioClip _lowTimeSound;
    [SerializeField]
    private AudioSource _soundEmitter;
    private bool _canPlaySound = true;
    public bool TimeIsExpired { get ; private set; }    

    // Update is called once per frame
    void Update()
    {
        _elapsedSecondsSinceReset += Time.deltaTime;
        if (_elapsedSecondsSinceReset > _collectionExpireTimeInSeconds)
        {
            TimeIsExpired = true;
        }
        if (!TimeIsExpired && (_collectionExpireTimeInSeconds - _elapsedSecondsSinceReset) < 1)
        {
            if (_lowTimeSound != null && _canPlaySound)
            {
                _soundEmitter.PlayOneShot(_lowTimeSound);
                _canPlaySound = false;
            }
        }
    }

    public void ResetTimer()
    {
        _elapsedSecondsSinceReset = 0;
        TimeIsExpired = false;
        _canPlaySound = true;
    }

    public float GetRemainingTimePercent()
    {
        float remainingTime;
        if (TimeIsExpired) 
        {
            remainingTime = 0f;
        }
        else
        {
            remainingTime = (_collectionExpireTimeInSeconds - _elapsedSecondsSinceReset);
        }
        return remainingTime / _collectionExpireTimeInSeconds;
    }
}
