using System;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private CharacterManager _selectedCharacter;
    private GameManager _gameManager;
    [SerializeField]
    private TextMeshProUGUI _textMesh;
    
    public event Action<object, EventArgs> OnCommandAddedToList;
    void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    void Start()
    {
        _gameManager.OnCharacterChange += gameManager_OnCharacterChange;
        OnCommandAddedToList += HandleOnCommandAddedToList;
    }

    public void HandleOnCommandAddedToList(object sender, EventArgs eventArgs)
    {
        uiUptadeCommandListGrid();
    }

    public void gameManager_OnCharacterChange(object sender, EventArgs e)
    {
        uiUpdateCharacter();
        uiChangeCharacterTitle();
    }

    public void uiUptadeCommandListGrid()
    {
        
    }

    public void uiUpdateCharacter()
    {
        _selectedCharacter = _gameManager.getSelectedCharacter();
    }

    public void uiChangeCharacterTitle()
    {
        String characterName = _selectedCharacter.getCharacterName();
        _textMesh.text = characterName;
    }

}
