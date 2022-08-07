using TMPro;
using UnityEngine;


public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winPanel;

    private void Awake()
    {
        SetActive(false);
    }

    private void Start()
    {
        LevelManager.Instance.OnAllBlocksDestroyed += GameWon;
        
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnAllBlocksDestroyed -= GameWon;
    }

    private void SetActive(bool isActive) =>
        _winPanel.gameObject.SetActive(isActive);

    private void GameWon()
    {
        
        _winPanel.gameObject.SetActive(true);
    }
}