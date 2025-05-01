using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SceneButtonHandler : MonoBehaviour
{
    [SerializeField]
    private string _buttonId;
    [SerializeField]
    private string _sceneToLoadName;

    private void OnEnable()
    {
        VisualElement rootDocument = GetComponent<UIDocument>().rootVisualElement;
        Button sceneButton = rootDocument.Q<Button>(_buttonId);
        if (sceneButton != null)
        {
            sceneButton.clicked += LoadScene;
        }
    }

    private void LoadScene()
    {
        StartCoroutine(loadSceneRoutine());
    }

    private IEnumerator loadSceneRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(_sceneToLoadName);
    }
}
