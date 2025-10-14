using UnityEngine;
public class UiAddCommandButton : UIButtonHandler
{
    [SerializeField]
    private CommandType _commandType;
    private GameManager _gameManager;
    public void Awake()
    {
        _gameManager = GameManager.Instance;
        base.Awake();
    }
    protected override void ButtonClicked()
    {

        if (GameManager.Instance != null)
        {
            Debug.Log("Botão para adicionar comando pressionado");
            return;
        }

        var selectedCharacter = GameManager.Instance.GetSelectedCharacter();
        if (selectedCharacter == null)
        {
            Debug.LogError("Nenhum personagem selecionado no GameManager!");
            return;
        }
        
        _gameManager.GetSelectedCharacter()?.AddCommandToList(_commandType);
        
    }
}
