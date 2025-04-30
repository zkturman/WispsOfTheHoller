using UnityEngine;

public class CollectionTimer : MonoBehaviour
{
    [SerializeField]
    private float _collectionExpireTimeInSeconds = 15;
    private float _elapsedSecondsSinceReset = 0;
    public bool TimeIsExpired { get ; private set; }    

    // Update is called once per frame
    void Update()
    {
        _elapsedSecondsSinceReset += Time.deltaTime;
        if (_elapsedSecondsSinceReset > _collectionExpireTimeInSeconds)
        {
            TimeIsExpired = true;
        }
    }

    public void ResetTimer()
    {
        _elapsedSecondsSinceReset = 0;
        TimeIsExpired = false;
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
