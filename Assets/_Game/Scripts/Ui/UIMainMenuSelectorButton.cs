using UnityEngine;
using UnityEngine.UI;

public class UiMainMenuSelectorButtonManager : UIButtonHandler
{
    [SerializeField]
    private int redirectionId;
    
    protected override void ButtonClicked()
    {
        LoadScene(redirectionId);
    }

    public void LoadScene(int redirectionId)
    {
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
