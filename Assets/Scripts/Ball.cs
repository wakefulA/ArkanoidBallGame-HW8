using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Variables

    private Vector2 _startDirection;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Pad _pad;

    [SerializeField] private float _speed = 10f;

    [Range(-1, 1)]
    [SerializeField] private float _xMin;

    [Range(-1, 1)]
    [SerializeField] private float _xMax;

    [Range(0, 1)]
    [SerializeField] private float _yMin;

    [Range(0, 1)]
    [SerializeField] private float _yMax;
    
    [SerializeField] public Ball _ball;

    #endregion
    
    
    private void Update()
    {

        if (GameManager.Instance._isStarted)
        {
            return;
        }
        
        MoveWithPad();
        Stop();
        
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }
    
    private void StartBall()
    {
        GameManager.Instance._isStarted = true;
        StartMove();
    }
    
    #region Unity lifecycle

    private void BallDirection()

    {
        Vector2 randomDirection = new Vector2(Random.Range(_xMin, _xMax), Random.Range(_yMin, _yMax));
        _startDirection = randomDirection.normalized * _speed;
    }

    private void Awake()
    {
        BallDirection();
      
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _startDirection);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _rb.velocity);
    }

    #endregion


    #region Public methods

    private void StartMove()
    {
        _rb.velocity = _startDirection;
        
    }

    private void MoveWithPad()
    {
        Vector3 padPosition = _pad.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = padPosition.x;
        transform.position = currentPosition;
    }

    #endregion
    
    private void Stop()
    {
       _rb.velocity = Vector2.zero;
       
    }

    
}