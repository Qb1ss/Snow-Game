using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private int _currentScene;

    private string _scenePP = "ScenePP";

    private ButtonGoNextPoint _goNextPointButton;


    private void Start()
    {
        //DontDestroyOnLoad(gameObject);

        _goNextPointButton = FindObjectOfType<ButtonGoNextPoint>();
    }


    public void GoNextScene()
    {
        _currentScene = SceneManager.sceneCount;
        PlayerPrefs.GetInt(_scenePP, _currentScene);

        SceneManager.LoadScene(_currentScene++);

        _goNextPointButton.gameObject.SetActive(true);
    }
}
