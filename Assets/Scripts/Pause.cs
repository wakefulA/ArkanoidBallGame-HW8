using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Image _pausePanel;

    private static Pause _instance;
    public static Pause Instance => _instance;

    public bool _isPaused;


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
        PausePanel();
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion


    private void PausePanel()
    {
        if (_isPaused == true)
        {
            _pausePanel.gameObject.SetActive(true);
        }

        if (_isPaused == false)
        {
            _pausePanel.gameObject.SetActive(false);
        }
    }


    #region Private methods

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
    }

    #endregion
}