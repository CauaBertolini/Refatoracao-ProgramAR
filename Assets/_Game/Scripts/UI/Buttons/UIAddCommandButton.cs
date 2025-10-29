using System;
using UnityEngine;
public class UiAddCommandButton : UIButtonHandler
{
    [SerializeField]
    private CommandType _commandType;
    private GameManager _gameManager;
    
    private GameManager _tryGetGameManager
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = GameManager.Instance;
                if (_gameManager == null)
                    Debug.LogWarning("[UiAddCommandButton] GameManager ainda não inicializado!");
            }
            return _gameManager;
        }
    }

    protected override void ButtonClicked()
    {
        var gameManager = _tryGetGameManager;
        
        if (gameManager == null)
        {
            Debug.LogError("[UiAddCommandButton] GameManager continua nulo ao clicar!");
            return;
        }

        var selectedCharacter = gameManager.GetSelectedCharacter();
        
        if (selectedCharacter == null)
        {
            Debug.LogWarning("[UiAddCommandButton] Nenhum personagem selecionado!");
            return;
        }
        
        selectedCharacter.AddCommandToList(_commandType);
        Debug.Log($"[UiAddCommandButton] Comando {_commandType} adicionado ao personagem {selectedCharacter.name}");
        
     
    }
}
