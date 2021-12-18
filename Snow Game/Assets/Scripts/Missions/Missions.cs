using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Missions : MonoBehaviour
{
    [Header("")]
    [SerializeField] private List<Mission> _mission;

    private int _currentMission;

    private ButtonGoNextPoint _goNextPointButton;


    private void Start()
    {
        _mission[_currentMission].Kills = 0;
        _mission[_currentMission].OnChecked();

        _goNextPointButton = FindObjectOfType<ButtonGoNextPoint>();
    }


    public void OnKill()
    {
        _mission[_currentMission].Kills++;
        _mission[_currentMission].OnChecked();

        if (_mission[_currentMission].IsFinished == true)
        {
            _mission[_currentMission].Kills = 0;

            if (_currentMission != _mission.Count)
            {
                _currentMission++;

                _goNextPointButton.gameObject.SetActive(true);
            }
        }
    }
}