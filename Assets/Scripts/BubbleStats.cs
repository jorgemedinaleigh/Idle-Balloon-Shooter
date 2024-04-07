using UnityEngine;

[CreateAssetMenu(menuName = "Data / Bubble Stats")]
public class BubbleStats : ScriptableObject
{
    public float xSpawnRange;
    public float ySpawnPos;
    public float zMaxPos;
    public float zMinPos;
    public float maxSpeed;
    public float minSpeed;
    public int popPoints;
}
