using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ManaBarHandler : ProgressBarHandler
{

    [SerializeField]
    private PlayerController _controller;

    protected override float GetPercentageDecimal()
    {
        return _controller.RemainingManaPercent();
    }
}
