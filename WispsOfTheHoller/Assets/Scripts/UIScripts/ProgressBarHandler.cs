using UnityEngine;
using UnityEngine.UIElements;

public abstract class ProgressBarHandler : MonoBehaviour
{
    [SerializeField]
    private string _progressBarFillId = "ManaBarFill";
    [SerializeField]
    private bool _isVertical = true;
    private VisualElement _rootDocument;
    protected VisualElement _progressBarFill;
    protected virtual void OnEnable()
    {
        _rootDocument = GetComponent<UIDocument>().rootVisualElement;
        _progressBarFill = _rootDocument.Q(_progressBarFillId);
    }

    private void Update()
    {
        Length barFill = Length.Percent(GetPercentageDecimal() * 100);
        if (_isVertical)
        {
            _progressBarFill.style.height = barFill;
        }
        else
        {
            _progressBarFill.style.width = barFill;
        }
    }

    protected abstract float GetPercentageDecimal();
}
