using UnityEngine;

[CreateAssetMenu(menuName = "Data / Tower Stats")]
public class TowerStats : ScriptableObject
{
    public float fireRate;
    public float fireRange;
    public int ammunition;
    public int price;
    public float rotationSpeed;
    public GameObject projectile;
}
