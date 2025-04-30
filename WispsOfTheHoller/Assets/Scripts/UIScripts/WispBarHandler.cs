using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class WispBarHandler : ProgressBarHandler
{
    private WispManager _wispManager;
    public void InjectWispManager(WispManager managerToInject)
    {
        _wispManager = managerToInject;
    }

    protected override float GetPercentageDecimal()
    {
        float collectionPercent = 0f;
        if (_wispManager != null)
        {
            collectionPercent = _wispManager.GetWispCollectionPercent();
        }
        return collectionPercent;
    }
}
