using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    public int LifeGame;

    public bool _isStarted;

    #endregion


    #region Events

    public event Action OnGameWon;

    #endregion


    #region Properies

    public int Score { get; private set; }

    #endregion


    private void Start()
    {
        LevelManager.Instance.OnAllBlocksDestroyed += PerformWin;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnAllBlocksDestroyed -= PerformWin;
    }


    #region Unity lifecycle

    #endregion


    #region Public methods

    public void ChangeScore(int score)
    {
        Score += score;
    }

    public void PerformWin()
    {
        OnGameWon?.Invoke();
    }

    #endregion


    #region Private methods

    #endregion


    public void LoseLife()
    {
        LifeGame--;
        _isStarted = false;
    }
}