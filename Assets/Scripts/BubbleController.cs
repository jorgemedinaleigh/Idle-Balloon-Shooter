using Unity.VisualScripting;
using UnityEngine;

public class BubbleController : MonoBehaviour
{ 
    [SerializeField] BubbleStats bubbleStats;

    private Rigidbody bubbleRb;
    private BankController bank;

    void Start()
    {
        bank = FindFirstObjectByType<BankController>();
        bubbleRb = GetComponent<Rigidbody>();

        transform.position = RandomSpawnPos();
        bubbleRb.AddForce(RandomForce(), ForceMode.Impulse);
    }

    private void OnMouseDown() 
    {
        ProcessPopping();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            ProcessPopping();
        }
    }

    private void ProcessPopping()
    {
        bank.Deposit(bubbleStats.popPoints);
        Destroy(gameObject);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-bubbleStats.xSpawnRange, bubbleStats.xSpawnRange), bubbleStats.ySpawnPos, Random.Range(bubbleStats.zMinPos, bubbleStats.zMaxPos));
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(bubbleStats.minSpeed, bubbleStats.maxSpeed);
    }
}
