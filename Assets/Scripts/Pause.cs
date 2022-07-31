using UnityEngine;

public class Pause : SingletonMonoBehaviout<Pause>
{
   
    
    public bool _isPaused;


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
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