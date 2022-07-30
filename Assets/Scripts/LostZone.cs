using UnityEngine;
using UnityEngine.SceneManagement;

public class LostZone : MonoBehaviour

{
    #region Unity Lifecycle
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            GameManager.Instance.LoseLife();
            
            
        }
        
    }
    
    

    

    #endregion
}