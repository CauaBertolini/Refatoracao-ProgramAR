using UnityEngine;
private GameObject _selectedCharacter;
private GameManager _gameManager;
public class UiManager : MonoBehaviour
{
    void Awake()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager != null)
        {
            _gameManager.OnCharacterChange += getCharacterSelected;
         }
    }

    public void getCharacterSelected() {
        _selectedCharacter = _gameManager.getCharacterSelected();
    }

    public void selectCharacter(GameObject character) {
        if (character != null)
        {
            this._characterSelected = character;
        }
    }

}
