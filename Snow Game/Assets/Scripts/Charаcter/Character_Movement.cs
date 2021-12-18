using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Character_Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5;

    private int _currentPoint;
    [Space(height: 5f)]

    [SerializeField] private Transform[] _waitPoints;

    [HideInInspector] public bool IsMoving = false;

    //[SerializeField] private Animator _animator;
    private NavMeshAgent _meshAgent;
    private Transform _transform;
    private Gun _gun;
    private SceneTransition _sceneTransition;
    private ButtonGoNextPoint _goNextPointButton;



    private void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        _gun = GameObject.FindObjectOfType<Gun>();
        _transform = GetComponent<Transform>();
        _sceneTransition = FindObjectOfType<SceneTransition>();
        _goNextPointButton = FindObjectOfType<ButtonGoNextPoint>();

        _goNextPointButton.GetComponent<Button>().onClick.AddListener(() => IsMoving = true);

        _meshAgent.speed = _moveSpeed;

        transform.position = _waitPoints[0].position;
    }


    private void Update()
    {
        Movement();
    }


    private void Movement()
    {
        if (IsMoving == true)
        {
            if (_currentPoint < _waitPoints.Length - 2)
            {
                _goNextPointButton.gameObject.SetActive(false);

                _gun.IsShooting = false;

                Vector3 tardetPosition = _waitPoints[_currentPoint + 1].position;

                _meshAgent.SetDestination(tardetPosition);

                if (_transform.position.z == tardetPosition.z)
                {
                    _gun.IsShooting = true;

                    _transform.LookAt(_waitPoints[_currentPoint + 2].position);

                    _currentPoint++;

                    IsMoving = false;
                }
            }
            else if (_currentPoint == _waitPoints.Length - 2)
            {
                _goNextPointButton.gameObject.SetActive(false);

                _gun.IsShooting = false;

                Vector3 tardetPosition = _waitPoints[_currentPoint + 1].position;

                _meshAgent.SetDestination(tardetPosition);

                if (_transform.position.z == tardetPosition.z)
                {
                    _sceneTransition.GoNextScene();                
                }
            }
        }
    }
}