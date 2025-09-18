using UnityEngine;
public class UiAddCommandButton : UIButtonHandler
{
    [SerializeField]
    private CommandType _commandType;
    private GameManager _gameManager;
    public void Awake()
    {
        base.Awake();
        _gameManager = GameManager.Instance;
    }
    protected override void ButtonClicked()
    {
        _gameManager.getSelectedCharacter()?.AddCommandToList(_commandType);
        
    }
}
