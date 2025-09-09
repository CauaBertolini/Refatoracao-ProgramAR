using System;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private CharacterManager _selectedCharacter;
    private GameManager _gameManager;
    void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    void Start()
    {
        _gameManager.OnCharacterChange += gameManager_OnCharacterChange;
    }

    public void gameManager_OnCharacterChange(object sender, EventArgs e)
    {
        
    }

    public void updateCharacter(CharacterManager character)
    {
        _selectedCharacter = character;
    }

}
