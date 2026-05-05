using UnityEngine;

public class respawn : MonoBehaviour

{
    public float threshold;
   
    void FixedUpdate()
    {
        if (transform.position.y < threshold) ;
        {
            transform.position = new Vector3(-7.85f, -3.27f, 0f);
        }
    }
}
