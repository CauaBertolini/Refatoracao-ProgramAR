using System;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private CharacterManager _selectedCharacter;
    private GameManager _gameManager;
    [SerializeField]
    private TextMeshProUGUI _textMesh;
    
    
    void Awake()
    {
        
    }

    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.OnCharacterChange += UiManager_OnCharacterChange;
        _gameManager.OnCommandListUpdate += HandleOnCommandListUpdate;
 
    }

    public void HandleOnCommandListUpdate(object sender, EventArgs eventArgs)
    {
        UiUptadeCommandListGrid();
    }

    public void UiManager_OnCharacterChange(object sender, EventArgs e)
    {
        UiUpdateCharacter();
        UiChangeCharacterTitle();
    }

    public void UiUptadeCommandListGrid()
    {
        
    }

    public void UiUpdateCharacter()
    {
        _selectedCharacter = _gameManager.GetSelectedCharacter();
    }

    public void UiChangeCharacterTitle()
    {
        String characterName = _selectedCharacter.getCharacterName();
        _textMesh.text = characterName;
    }

}
