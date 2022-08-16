using TMPro;
using UnityEngine;

public class LifeGamesLabel : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI _lifeGames;

    private void Update()
    {
        _lifeGames.text = $"Life {GameManager.Instance.LifeGame}";
    }
}