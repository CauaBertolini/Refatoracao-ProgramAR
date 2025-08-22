using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLevelSelectorButtonManager : UIButtonHandler
{
    [SerializeField]
    private int levelIndex;
    [SerializeField]
    private TextMeshProUGUI levelText;
    private string prefix = "Level";

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


