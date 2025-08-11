using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLevelSelectorButtonManager : MonoBehaviour
{
    [SerializeField]
    private int levelIndex;
    [SerializeField]
    private TextMeshProUGUI levelText;
    private string prefix = "Level";

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadLevel);
        levelText.text = levelIndex.ToString();
    }
    void LoadLevel()
    {
        string levelName = prefix + levelIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}


