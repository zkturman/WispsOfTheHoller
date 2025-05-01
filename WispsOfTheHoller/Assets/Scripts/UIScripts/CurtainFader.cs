using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class CurtainFader : MonoBehaviour
{
    [SerializeField]
    private string _curtainId = "Curtain";

    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        VisualElement curtainElement = rootElement.Q(_curtainId);
        curtainElement.AddToClassList("fade-in");
    }
}
