using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    private static GameManager _instance;

    public int LifeGame;

    public static GameManager Instance => _instance;

    [SerializeField] private Ball _ball;
    

    private bool _isStarted;

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

    private void Update()
    {
        

        if (_isStarted)
        {
            return;
        }
            
        _ball.MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
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

    private void StartBall()
    {
        _isStarted = true;
        _ball.StartMove();
    }

    #endregion


    public void LoseLife()
    {
        LifeGame--;
        _isStarted = false;
        _ball.Stop();
        // TODO: logic with ball
    }
}