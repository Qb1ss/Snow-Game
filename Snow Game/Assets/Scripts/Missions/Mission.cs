using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] private int _target;
    [HideInInspector] public int Kills;

    [SerializeField] private bool _isFinilyMission = false;
    [HideInInspector] public bool IsFinished = false;


    public void OnChecked()
    {
        if (_isFinilyMission == false)
        {
            if (Kills < _target)
            {
                IsFinished = false;
            }
            else if (Kills >= _target)
            {
                IsFinished = true;
            }
        }
    }
}