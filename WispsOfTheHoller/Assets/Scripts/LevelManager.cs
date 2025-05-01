using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    private WispManager _wispManager;
    private CollectionTimer _collectionTimer;

    private void Awake()
    {
        if ( _instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _wispManager = GetComponent<WispManager>();
        _collectionTimer = GetComponent<CollectionTimer>();
        SetUiDependencies();
    }

    private void SetUiDependencies()
    {
        TimerBarHandler timerUi = FindFirstObjectByType<TimerBarHandler>();
        if (timerUi != null)
        {
            timerUi.InjectCollecitonTimer(_instance._collectionTimer);
        }
        WispBarHandler wispUi = FindFirstObjectByType<WispBarHandler>();
        if (wispUi != null)
        {
            wispUi.InjectWispManager(_instance._wispManager);
        }
    }

    public static void ResetLevel()
    {
        if (_instance._wispManager.CanReset())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.sceneLoaded += reloadLevel;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
            SceneManager.sceneLoaded += destroyInstance;
        }
    }

    public static void FinishGame()
    {
        SceneManager.LoadScene("Credits");
        SceneManager.sceneLoaded += destroyInstance;
    }

    private static void reloadLevel(Scene scene, LoadSceneMode mode)
    {
        _instance._wispManager.ResetCollection();
        _instance._collectionTimer.ResetTimer();
        _instance.SetUiDependencies();
        SceneManager.sceneLoaded -= reloadLevel;
    }

    private static void destroyInstance(Scene scene, LoadSceneMode mode)
    {
        Destroy(_instance.gameObject);
        SceneManager.sceneLoaded -= destroyInstance;
    }
}
