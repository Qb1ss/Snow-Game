using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header ("Progress Bar")]
    [SerializeField] private Text _currentLevelText;
    [SerializeField] private Text _nextLevelText;
    [Space(height: 5f)]

    [SerializeField] private Text _progressInLevelText;

    [SerializeField] private Slider _progressInLevelSlider;

    private int _currentScene;

    private string _scenePP = "ScenePP";

    private ButtonGoNextPoint _goNextPointButton;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _goNextPointButton = FindObjectOfType<ButtonGoNextPoint>();

        _currentScene = PlayerPrefs.GetInt(_scenePP);

        UpdateUIProgressBar();
    }


    public void GoNextScene()
    {
        _currentScene++;
        PlayerPrefs.SetInt(_scenePP, _currentScene);

        if (_currentScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_currentScene);

            UpdateUIProgressBar();
        }
        else
        {
            _currentScene = 0;
            PlayerPrefs.SetInt(_scenePP, _currentScene);

            SceneManager.LoadScene(0);

            UpdateUIProgressBar();
        }

        _goNextPointButton.gameObject.SetActive(true);
    }


    private void UpdateUIProgressBar()
    {
        

        _currentLevelText.text = _currentScene.ToString();
        _nextLevelText.text = (_currentScene + 1).ToString();
    }


    public void UpdateUIProgressBarSlider(int currentMission, int maxMissions)
    {
        _progressInLevelSlider.maxValue = maxMissions;
        _progressInLevelSlider.value = currentMission;

        _progressInLevelText.text = $"{currentMission}/{maxMissions}";
    }
}