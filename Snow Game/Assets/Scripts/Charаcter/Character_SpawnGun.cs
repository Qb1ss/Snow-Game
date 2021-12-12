using UnityEngine;

public class Character_SpawnGun : MonoBehaviour
{
    [Header("Guns")]
    //[SerializeField] private List<Gun> _guns;

    [Header("Parameters")]
    [SerializeField] private Transform _gunSpawnPoint;


    private void Start()
    {
        //GameObject newClonedObject = Instantiate(_guns[0].gameObject, _gunSpawnPoint.transform.position, Quaternion.identity);
        //newClonedObject.transform.parent = _gunSpawnPoint;
    }
}