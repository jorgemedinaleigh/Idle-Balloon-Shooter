using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> bubbles;
    [SerializeField] float spawnRateMin;
    [SerializeField] float spawnRateMax;

    void Start()
    {
        int index = Random.Range(0, bubbles.Count);
        Instantiate(bubbles[index]);
        StartCoroutine(SpawnBubbles());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnBubbles()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));

            int index = Random.Range(0, bubbles.Count);
            Instantiate(bubbles[(int)index]);
        }
    }
}
