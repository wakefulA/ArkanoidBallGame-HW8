using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField] private Image _pausePanel;

    private void PausePanel()
    {
        if (Pause.Instance._isPaused == true)
        {
            _pausePanel.gameObject.SetActive(true);
        }

        else _pausePanel.gameObject.SetActive(false);
        
        
    }

    

    private void Update()

    {
        PausePanel();
    }
}