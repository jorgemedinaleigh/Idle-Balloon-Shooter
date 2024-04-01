using UnityEngine;

[CreateAssetMenu(menuName = "Tower Manager / Tower Stats")]
public class TowerStats : ScriptableObject
{
    public float fireRate;
    public float fireRange;
    public int ammunition;
    public float bulletSpeed;
    public GameObject bullet;
}
