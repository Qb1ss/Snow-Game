using UnityEngine;
using System.Collections.Generic;

public class Missions : MonoBehaviour
{
    [Header("")]
    [SerializeField] private List<Mission> _mission;

    [HideInInspector] public int _currentMission;

    private ButtonGoNextPoint _goNextPointButton;
    private SceneTransition _sceneTransition;


    private void Start()
    {
        _mission[_currentMission].Kills = 0;
        _mission[_currentMission].OnChecked();

        _goNextPointButton = FindObjectOfType<ButtonGoNextPoint>();
        _sceneTransition = FindObjectOfType<SceneTransition>();

        _sceneTransition.UpdateUIProgressBarSlider(_currentMission, _mission.Count);
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

        _sceneTransition.UpdateUIProgressBarSlider(_currentMission, _mission.Count);
    }
}