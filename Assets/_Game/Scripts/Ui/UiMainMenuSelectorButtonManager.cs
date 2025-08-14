using UnityEngine;
using UnityEngine.UI;

public class UiMainMenuSelectorButtonManager : MonoBehaviour
{
    [SerializeField]
    private int redirectionId;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(loadScene);
    }

    public void loadScene() {
        switch (redirectionId)
        {
            case 1:
                //Última fase desbloqueada pelo jogador
                break;
            case 2:
                Debug.Log("Cena carregada");
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelector");
                break;
            case 3:
                break;
            default:
                break;
        }

    }

}
