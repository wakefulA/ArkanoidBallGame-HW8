using UnityEngine;

public class Pause : SingletonMonoBehaviour<Pause>
{
    public bool _isPaused;


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void GameStop()
    {
        if (GameManager.Instance._isStarted == false)
        {
            return;
        }

        Time.timeScale = 0;
    }

    #endregion


    #region Private methods

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
    }

    #endregion
}