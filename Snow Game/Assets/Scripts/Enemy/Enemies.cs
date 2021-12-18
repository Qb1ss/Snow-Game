using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Enemies : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform _targetPosition;

    private Character_Movement _character_Movement;


    private void Start()
    {
        _character_Movement = FindObjectOfType<Character_Movement>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        _character_Movement.transform.LookAt(gameObject.transform.position);

        var gun = FindObjectOfType<Gun>();

        gun.OnClickToShoot();

        var bulletProjectile = FindObjectOfType<Bullet>();

        bulletProjectile.TargetBulletPosition = _targetPosition.position;
    }
}