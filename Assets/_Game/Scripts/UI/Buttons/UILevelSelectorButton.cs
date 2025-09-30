using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLevelSelectorButton : UIButtonHandler
{
    [SerializeField]
    private int levelIndex;
    [SerializeField]
    private TextMeshProUGUI levelText;
    private string prefix = "Level";

    void Start()
    {
        levelText.text = levelIndex.ToString();
    }
    protected override void ButtonClicked()
    {
        LoadLevel();
    }
    void LoadLevel()
    {
        string levelName = prefix + levelIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}


