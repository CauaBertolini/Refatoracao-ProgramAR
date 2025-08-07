using UnityEngine;
using UnityEngine.UI;

public class UiLevelSelectorButtonManager : MonoBehaviour
{
    [SerializeField]
    private int levelIndex;
    private string prefix = "Level";

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadLevel);
    }
    void LoadLevel()
    {
        string levelName = prefix + levelIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}


