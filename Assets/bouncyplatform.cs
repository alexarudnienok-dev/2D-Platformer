using UnityEngine;

public class bouncyplatform : MonoBehaviour
{
    private float bounce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        
    }
}
