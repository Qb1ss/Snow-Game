using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject _enemy;

    [Header("Spawner Parameters")]
    [SerializeField] private float _range = 1;


    private void Start()
    {
        Instantiate(_enemy, transform.position, Quaternion.Euler(0f, 180f, 0f));
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(gameObject.transform.position, _range);
    }
}