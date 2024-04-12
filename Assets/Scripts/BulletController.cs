using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Tower")
        {
            Destroy(gameObject);
        }
    }
}
