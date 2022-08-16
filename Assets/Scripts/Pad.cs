using UnityEngine;

public class Pad : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    [SerializeField] private Vector3 _minSize;

    [SerializeField] private Vector3 _maxSize;


    #region Variables

    private Ball _ball;

    #endregion


    public Vector3 StartPadSize { get; private set; }


    #region Unity lifecycle

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (Pause.Instance.IsPaused)
            return;
        if (GameManager.Instance.LifeGame == 0)
            return;


        if (GameManager.Instance.NeedAutoPlay)
        {
            MoveWithBall();
        }

        else
        {
            MoveWithMouse();
        }
    }

    #endregion


    #region Private methods

    private void MoveWithMouse()
    {
        Vector3 mousePositionInPixels = Input.mousePosition;
        Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
        Vector3 currentPosition = transform.position;
        currentPosition.x = mousePositionInUnits.x;
        transform.position = currentPosition;
    }

    private void MoveWithBall()
    {
        Vector3 ballPosition = _ball.transform.position;

        Vector3 currentPosition = transform.position;
        currentPosition.x = ballPosition.x;
        transform.position = currentPosition;
    }

    #endregion


    public void ChangeSizePad(float size)
    {
        Vector3 actualSizePad = transform.localScale * size;
        actualSizePad *= size;
        if (actualSizePad.magnitude > _maxSize.magnitude)
        {
            actualSizePad = _maxSize;
        }


        if (actualSizePad.magnitude > _minSize.magnitude)
        {
            actualSizePad = _minSize;
        }

        transform.localScale = actualSizePad;
    }
}