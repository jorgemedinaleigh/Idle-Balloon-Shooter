using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] float xSpawnRange;
    [SerializeField] float ySpawnPos;
    [SerializeField] float zMinPos;
    [SerializeField] float zMaxPos;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    [SerializeField] int popPoints;

    private Rigidbody bubbleRb;

    void Start()
    {
        bubbleRb = GetComponent<Rigidbody>();

        transform.position = RandomSpawnPos();
        bubbleRb.AddForce(RandomForce(), ForceMode.Impulse);
    }

    void Update()
    {
        
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos, Random.Range(zMinPos, zMaxPos));
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
}
