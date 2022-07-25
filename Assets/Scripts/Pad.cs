using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Unity lifecycle

    private void Update()
    {
        if (Pause.Instance._isPaused)
            return;
        Vector3 mousePositionInPixels = Input.mousePosition;
        if (Pause.Instance._isPaused)
            return;
        Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
        if (Pause.Instance._isPaused)
            return;
        Vector3 currentPosition = transform.position;
        if (Pause.Instance._isPaused)
            return;
        currentPosition.x = mousePositionInUnits.x;
        if (Pause.Instance._isPaused)
            return;
        transform.position = currentPosition;
        if (Pause.Instance._isPaused)
            return;
    }

    #endregion
}