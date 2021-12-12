using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Camera Parameters")]
    [SerializeField] private float _cameraSmooth = 5f;

    [SerializeField] private Vector3 _cameraOffset = new Vector3(2.5f, 3, -6);

    private Character_Movement _player;


    private void Start()
    {
        _player = GameObject.FindObjectOfType<Character_Movement>();
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position + _cameraOffset, Time.deltaTime * _cameraSmooth);
    }
}