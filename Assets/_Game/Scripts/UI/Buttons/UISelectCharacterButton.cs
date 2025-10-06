using System;
using UnityEngine;

public class UISelectCharacterButton : UIButtonHandler
{
    private GameManager _gameManager;
    [SerializeField]
    private int _uiCharacterId;
    
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    protected override void ButtonClicked() {
        SelectCharacter();
    }

    public void SelectCharacter()
    {
        _gameManager.SelectCharacterById(_uiCharacterId);
    }
}
