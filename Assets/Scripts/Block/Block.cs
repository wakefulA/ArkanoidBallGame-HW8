using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _pickup;

    [Header("Block")]
    [SerializeField] private int _score;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Pick Up")]
    [Range(0f, 1f)]
    [SerializeField] private GameObject _pickUpPrefab;
    [SerializeField] private PickUpInfo[] _pickUpInfoArray;
    [SerializeField] private float _pickUpSpawnChanse;

    [Header("Music")]
    [SerializeField] private AudioClip _audioClip;
    

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
        //change hp
        // if(hp ==0)
        //DestroyBlock();
        
        DestroyBlock();
    }

   

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this, _score);
        GameManager.Instance.ChangeScore(_score);

        Instantiate(_pickup, Vector3.one, Quaternion.identity);
    }

    private void OnValidate()
    {
        if (_pickUpInfoArray == null || _pickUpInfoArray.Length == 0)
            return;

        foreach (PickUpInfo pickUpInfo in _pickUpInfoArray)
            pickUpInfo.UpdateName();
    }


    #region Public methods 

    public virtual void DestroyBlock()
    {
        
       
        AudioPlayer.Instance.PlaySound(_audioClip);
        SpawnPickUp();

        _life--;
        if (_life == 0)
            Destroy(gameObject);
        if (_color.a <= 0)
            _spriteRenderer.color = Color.blue;
     
        
    }

    #endregion
    
    

    #endregion


    #region Private methods

    private void SpawnPickUp()
    {
        if (_pickUpInfoArray == null || _pickUpInfoArray.Length == 0)
            return;
        float random = Random.Range(0f, 1f);
        if (random <= _pickUpSpawnChanse)
        {
            return;
        }

        int chanceSum = 0;
        foreach (PickUpInfo pickUpInfo in _pickUpInfoArray)
        {
            chanceSum += pickUpInfo.SpawnChance;
        }

        int randomChance = Random.Range(0, chanceSum);
        int currentChance = 0;
        int currentIndex = 0;
        for (int i = 0; i < _pickUpInfoArray.Length; i++)
        {
            PickUpInfo pickUpInfo = _pickUpInfoArray[i];
            currentChance += pickUpInfo.SpawnChance;

            if (currentChance >= randomChance)
            {
                currentIndex = i;
                break;
            }
        }


        PickUpBase pickUpPrefab = _pickUpInfoArray[currentIndex].PickUpPrefab;
        Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
    }

    #endregion
}