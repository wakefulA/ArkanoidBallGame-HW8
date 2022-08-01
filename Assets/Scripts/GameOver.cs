using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOver;

    private void Update()
    {
        if (GameManager.Instance.LifeGame == 0)
        {
            _gameOver.text = $"Game over   Score: {GameManager.Instance.Score}";

            Pause.Instance.GameStop();
        }
    }
}