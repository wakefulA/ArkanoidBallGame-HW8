using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _score;

    [SerializeField] private Sprite[] _sprites;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Color _color;

    #endregion


    #region Events

    public static event Action OnCreated;
    public static event Action OnDestroyed;

    #endregion


    #region Variables

    private int _life = 3;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _life--;
        if (_life == 0)
            Destroy(gameObject);


        if (_color.a <= 0)
            _spriteRenderer.color = Color.blue;
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke();

        GameManager.Instance.AddScore(_score);
    }

    #endregion
}