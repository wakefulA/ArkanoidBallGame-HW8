using System;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private bool _needAutoPlay;


    #region Variables

    public int LifeGame;

    public bool _isStarted;

    #endregion


    #region Events

    public event Action OnGameWon;

    #endregion


    #region Properies

    public bool NeedAutoPlay => _needAutoPlay;

    public int Score { get; private set; }

    #endregion


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

    #endregion


    #region Private methods

    #endregion


    public void LoseLife()
    {
        LifeGame--;
        _isStarted = false;
    }
}