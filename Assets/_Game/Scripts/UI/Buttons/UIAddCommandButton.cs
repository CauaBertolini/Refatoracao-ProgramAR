using System;
using UnityEngine;
public class UiAddCommandButton : UIButtonHandler
{
    [SerializeField]
    private CommandType _commandType;
    private GameManager _gameManager;
    
    private GameManager GM
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
        var gm = GM;
        if (gm == null)
        {
            Debug.LogError("[UiAddCommandButton] GameManager continua nulo ao clicar!");
            return;
        }

        var selected = gm.GetSelectedCharacter();
        if (selected == null)
        {
            Debug.LogWarning("[UiAddCommandButton] Nenhum personagem selecionado!");
            return;
        }
        selected.AddCommandToList(_commandType);
        Debug.Log($"[UiAddCommandButton] Comando {_commandType} adicionado ao personagem {selected.name}");
        
     
    }
}
