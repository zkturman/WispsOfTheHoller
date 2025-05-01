using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class QuitButtonHandler: MonoBehaviour
{
    [SerializeField]
    private string _quitButtonId = "QuitButton";

    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        Button quitButton = rootElement.Q<Button>(_quitButtonId);
        quitButton.clicked += () =>
        {
            StartCoroutine(quitRoutine());
        };
    }

    private IEnumerator quitRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
