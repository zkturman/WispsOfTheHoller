using UnityEngine;

public class TimerBarHandler : ProgressBarHandler
{
    private CollectionTimer _collectionTimer;
    public void InjectCollecitonTimer(CollectionTimer timerToInject)
    {
        _collectionTimer = timerToInject;
    }

    protected override float GetPercentageDecimal()
    {
        float remainingTime = 1;
        if (_collectionTimer != null)
        {
            remainingTime = _collectionTimer.GetRemainingTimePercent();
        }
        return remainingTime;
    }
}
