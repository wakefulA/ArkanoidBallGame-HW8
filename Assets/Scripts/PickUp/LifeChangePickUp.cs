using UnityEngine;

public class LifeChangePickUp : PickUpBase
{
    [Header(nameof(LifeChangePickUp))]
    [SerializeField] private int _life;

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<GameManager>().LifeChange(_life);
    }
}