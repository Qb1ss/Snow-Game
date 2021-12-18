using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Spawn Point")]
    [SerializeField] private Transform _bulletSpawnPoint;

    [Header("Bullet")]
    [SerializeField] private Bullet _bulletProjectile;

    [HideInInspector] public bool IsShooting;


    public void OnClickToShoot()
    {
        if(IsShooting == true)
        {
            Instantiate(_bulletProjectile.gameObject, _bulletSpawnPoint.position, Quaternion.identity);
        }
    }
}