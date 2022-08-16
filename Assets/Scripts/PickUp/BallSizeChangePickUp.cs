using UnityEngine;

public class BallSizeChangePickUp : PickUpBase
{
    [Header(nameof(BallSizeChangePickUp))]
    [Range(2f, 4f)]
    [SerializeField] private float _size;

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeSizeBall(_size);
    }
}