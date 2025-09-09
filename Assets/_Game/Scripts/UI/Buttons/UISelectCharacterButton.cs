using System;
using UnityEngine;

public class UISelectCharacterButton : UIButtonHandler
{
    private GameManager _gameManager;
    [SerializeField]
    private int _characterId;
    
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    protected override void ButtonClicked() {
        selectCharacter();
    }

    public void selectCharacter()
    {
        _gameManager.selectCharacterById(_characterId);
    }
}
