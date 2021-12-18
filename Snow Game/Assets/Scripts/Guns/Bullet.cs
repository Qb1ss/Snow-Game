using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public event UnityAction Hitted;

    [Header("Bullet Parameters")]
    [SerializeField] private float _speed = 30;

    [HideInInspector] public Vector3 TargetBulletPosition;


    private void Start()
    {
        Destroy(gameObject, 1f);
    }


    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        transform.LookAt(TargetBulletPosition);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemies>(out Enemies enemy))
        {
            Destroy(enemy.gameObject);

            if (enemy.enabled == false)
            {
                var missions = FindObjectOfType<Missions>();

                missions.OnKill();

                Destroy(gameObject);
            }
        }
    }
}