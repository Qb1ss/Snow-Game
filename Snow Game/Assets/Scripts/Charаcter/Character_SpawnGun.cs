using UnityEngine;
using System.Collections.Generic;

public class Character_SpawnGun : MonoBehaviour
{
    [Header("Guns")]
    [SerializeField] private List<Gun> _guns;

    [Header("Parameters")]
    [SerializeField] private Transform _gunSpawnPoint;


    private void Start()
    {
        GameObject newClonedObject = Instantiate(_guns[Random.Range(0, _guns.Count)].gameObject, _gunSpawnPoint.transform.position, Quaternion.identity);
        newClonedObject.transform.parent = _gunSpawnPoint;
    }
}