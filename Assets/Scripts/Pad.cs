using UnityEngine;

public class Pad : MonoBehaviour
{
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

        float actualSizePad = gameObject.transform.localScale.x;
        if (actualSizePad == size * StartPadSize.x)
            return;
        Pad[] pads = FindObjectsOfType<Pad>();
        foreach (Pad pad in pads)
            pad.transform.localScale *= size;

    }

   

}