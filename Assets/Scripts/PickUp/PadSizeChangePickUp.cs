using UnityEngine;

public class PadSizeChangePickUp : PickUpBase
{
    
    [Header(nameof(PadSizeChangePickUp))]
    [Range(0.1f, 1.5f)]
    [SerializeField] private float _size ;
    
    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Pad>().ChangeSizePad(_size);
       
    }
}
