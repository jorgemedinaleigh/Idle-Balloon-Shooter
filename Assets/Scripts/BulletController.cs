using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Tower")
        {
            Destroy(gameObject);
        }
    }
}
