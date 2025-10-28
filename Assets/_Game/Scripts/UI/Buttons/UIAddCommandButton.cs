using System;
using UnityEngine;
public class UiAddCommandButton : UIButtonHandler
{
    [SerializeField]
    private CommandType _commandType;
    private GameManager _gameManager;

    void Start()
    {
        Debug.Log("UiAddComandButton Verificando ----------------------------------------------");
        _gameManager = GameManager.Instance;
        Debug.Log($"[UiAddCommandButton] Start: GameManager.Instance = {_gameManager}");
    }

    protected override void ButtonClicked()
    {

        if (GameManager.Instance != null)
        {
            Debug.Log("Botão para adicionar comando pressionado");
        }


        if (_gameManager.GetSelectedCharacter() != null)
        {
            Debug.Log("Comando adicionado");
            _gameManager.GetSelectedCharacter().AddCommandToList(_commandType);
        } 
        else
        {
            Debug.Log("Por algum motivo não foi adicionado");
        }
        
     
    }
}
