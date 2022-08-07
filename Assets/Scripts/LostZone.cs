using UnityEngine;

public class LostZone : MonoBehaviour

{
    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball ))
        {
            GameManager.Instance.LoseLife();
        }

        if (collision.gameObject.CompareTag(Tags.Ball))
        {

            // GameManager.Instance.LoseLife();

            // TODO: соприкоснулись с мячиком
        }

        else
        {
            Destroy(collision.gameObject);
            
        }
        
        
    }

    #endregion
}

