using System;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [SerializeField] private bool _needAutoPlay;

    public int LifeGame;

    public bool _isStarted;

    #endregion


    #region Events

    public event Action OnGameWon;

    #endregion


    #region Properies

    public bool NeedAutoPlay => _needAutoPlay;

    public int Score { get; private set; }

    public int Life { get; private set; }

    #endregion


    #region Private methods

    private void Start()
    {
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed += PerformWin;
    }

    private void OnDestroy()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
            levelManager.OnAllBlocksDestroyed -= PerformWin;
    }

    #endregion


    #region Public methods

    public void ChangeScore(int score)
    {
        Score += score;
    }

    private void PerformWin()
    {
        Debug.LogError($"WIN!");

        OnGameWon?.Invoke();
    }

    public void LoseLife()
    {
        LifeGame--;
        _isStarted = false;
    }

    public void LifeChange(int life)
    {
        LifeGame += life;
    }

    #endregion
}