using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables
    
    private int _life = 3;
    
    #endregion
    
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        _life--;
        if (_life == 0)
            Destroy(gameObject);
    }

    #endregion
}
