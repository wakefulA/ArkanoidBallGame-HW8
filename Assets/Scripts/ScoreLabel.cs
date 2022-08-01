using TMPro;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private void Update()
    {
        _score.text = $"Score {GameManager.Instance.Score}";
    }
}