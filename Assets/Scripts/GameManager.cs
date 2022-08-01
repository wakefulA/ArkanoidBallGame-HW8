public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    public int LifeGame;

    public bool _isStarted;

    #endregion


    #region Properies

    public int Score { get; private set; }

    #endregion


    private void Start()
    {
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed += PerformWin;
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed -= PerformWin;
    }


    #region Unity lifecycle

    #endregion


    #region Public methods

    public void AddScore(int score)
    {
        Score += score;
    }

    private void PerformWin()
    {
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