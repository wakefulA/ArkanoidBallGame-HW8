using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Ball _ball;

    private bool _isStarted;
    private int _playerLives;
    private int _playerPoints;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (_isStarted)

            return;

        _ball.MoveWithPad();


        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        _isStarted = true;
        _ball.StartMove();
    }

    #endregion
}