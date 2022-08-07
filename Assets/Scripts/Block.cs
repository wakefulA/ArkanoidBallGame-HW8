using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Block")]
    [SerializeField] private int _score;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Pick Up")]
    [SerializeField] private GameObject _pickUpPrefab;

    [Range(0f, 1f)] // 0 - нул вер-ть 1 - 100% вер-ть 
    [SerializeField] private float _pickUpSpawnChanse;

    private Color _color;

    #endregion


    #region Events

    public static event Action<Block> OnCreated;
    public static event Action<Block, int> OnDestroyed;

    #endregion


    #region Variables

    private int _life = 2;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        SpawnPickUp();


        _life--;
        if (_life == 0)
            Destroy(gameObject);
        if (_color.a <= 0)
            _spriteRenderer.color = Color.blue;
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this, _score);
        GameManager.Instance.ChangeScore(_score);
    }

    #endregion


    #region Private methods

    private void SpawnPickUp()
    {
        if(_pickUpPrefab ==  null)
            return;
        
        if (_pickUpPrefab == null)
            return;


        float random = Random.Range(0f, 1f);
        if (random <= _pickUpSpawnChanse)
        {
            Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
            // TODO: Spawn
        }
    }

    #endregion
}