using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    private static GameManager _instance;

    public int LifeGame;

    public static GameManager Instance => _instance;

    
    

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


    #region Public methods

    public void AddScore(int score)
    {
        Score += score; 
    }

    public void PerformWin()
    {
        Debug.LogError($"WIN!");
    }

    #endregion


    #region Private methods

   

    #endregion


    public void LoseLife()
    {
        LifeGame--;
        _isStarted = false;
       

        // TODO: logic with ball
    }
}