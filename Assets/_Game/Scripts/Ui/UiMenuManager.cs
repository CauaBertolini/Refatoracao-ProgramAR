using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UiMenuManager : MonoBehaviour
{

    private GameManager _gameManager; 
    private int _levelCapther = 0;

    void Start()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager != null) 
        {
            //Adicionar aqui as inscrições para os eventos do GameManager.
        } else 
        {
            Debug.Log("Game Manager nulo para 'UiMenuManager'");
        }
    }

    public void SetGrid() 
    {
        UpdateLevelTitleInMenu();
        int levelID = GetMaxProgressUnlocked();
        levelID++;
        UpdateLevelButtons();
    }

    public void UpdateLevelTitleInMenu()
    {
        switch (_levelCapther)
        {
            case 0: levelTitle.text = "Ações"; break;
            case 1: levelTitle.text = "Funções"; break;
            case 2: levelTitle.text = "Repetições"; break; 
        }
    }

    private int GetMaxProgressUnlocked() //VERIFICAR SE ESSA CLASSE NÂO PODERIA IR PARA O GAME MANAGER
    {
        int nivelAlcancado = PlayerPrefs.GetInt($"_levelCapther{_levelCapther}", 0) + 1;
        return Mathf.Clamp(nivelAlcancado, 1, 5); // Garante que não passe do máximo
    }

    private void UpdateLevelButtons() //REFATORAR ESSE MÉTODO PARA NÃO SOLICITAR PARÂMETRO E NÃO RETORNAR PARÂMETRO
    { 
        for (int i = 0; i < levels.Count; i++)
        {
            GameObject botao = levels[i];
            Image imagem = botao.GetComponent<Image>();
            TextMeshProUGUI texto = botao.GetComponentInChildren<TextMeshProUGUI>();
            GameObject icone = botao.transform.GetChild(0).gameObject;

            bool isUnlocked = i < _gameManager.higherUnlockedLevel;

            icone.SetActive(isUnlocked);
            texto.text = (i + 1).ToString();

            string spritePath = GetSpritePathParaNivel(isUnlocked, _levelCapther);
            imagem.sprite = Resources.Load<Sprite>(spritePath);
        }
    }

    private string GetSpritePathParaNivel(bool unlocked, int levelCapther) //REFATORAR ESSE MÉTODO
    {
        if (!unlocked)
        {
            return levelCapther switch
            {
                0 => "UI/Sprites/LevelLocked_Blue",
                1 => "UI/Sprites/LevelLocked_Green",
                2 => "UI/Sprites/LevelLocked_Orange",
                _ => "UI/Sprites/LevelLocked_Blue"// Buscar entender essa atribuição inédita
            };
        }
        return levelCapther switch
        {
            0 => "UI/Sprites/blue_panel",
            1 => "UI/Sprites/green_panel",
            2 => "UI/Sprites/orange_panel",
            _ => "UI/Sprites/blue_panel"
        };
    }

    public void SelectLevel()
    {
        if (level.transform.GetChild(0).gameObject.activeSelf == false) //Entender o getChild
                    return;

                GlobalControll.levelID = int.Parse(level.name.Remove(0, 5));
                GlobalControll._levelCapther = this._levelCapther;

                SceneManager.LoadScene("InGame", LoadSceneMode.Single);
    }

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public void GoToNextLevel()
    {
        bool next = true;

        if (++GlobalControll.levelID > 5)
        {
            GlobalControll.levelID = 1;

            if (++GlobalControll._levelCapther > 1)
            {
                next = false;
                SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
            }
        }

        if (next) 
        {
            SceneManager.LoadScene("InGame", LoadSceneMode.Single);
        }
            
    }

    public void GoToNextPage()
    {
        if (_levelCapther < 1)
                {
                    _levelCapther++;

                    SetGrid();
                }
    }

    public void GoToPreviousPage()
    {
        if (_levelCapther > 0)
                {
                    _levelCapther--;

                    SetGrid();
                }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayStop() //Refatorar para ser um botão estilo Try e outro para Stop
    {
        if (!gameControll.enabled)
            return;

        if (gameControll.runningAlgorithm)
            GameManager.RestartLevel();
        else
        {
            gameControll.runningAlgorithm = true;
            gameControll.logScreen.transform.parent.gameObject.SetActive(false);

            logBtn.SetActive(false);

            btnPlay.sprite = Resources.Load<Sprite>("UI/Sprites/Stop");

            GameObject.FindObjectOfType<Map>()?.Close();
        }

    }

    public void OnDestroy()
    {

    }
}
