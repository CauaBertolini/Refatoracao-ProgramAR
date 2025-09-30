using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<CharacterManager> _characters = new List<CharacterManager>();
    
    [SerializeField]
    private CharacterManager _selectedCharacter;

    private int levelType = 0;
    private int levelID { get; set; } = 0;
    private int higherUnlockedLevel { get; set; } = 0;
    public event Action<object, EventArgs> OnGameStart;
    public event Action<object, EventArgs> OnGameEnd;
    public event Action<object, EventArgs> OnCallTutorial;
    public event Action<object, EventArgs> OnCallCommandListsExecution;
    public event Action<object, EventArgs> OnCharacterChange;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    void Start()
    {
        _characters = FindObjectsOfType<CharacterManager>().ToList();
        Debug.Log(_characters.Count);
        
        OnGameStart += HaldleOnGameStart;
        OnGameEnd += HaldleOnGameEnd;
        OnCallTutorial += HandleOnCallTutorial;

    }

    void Update()
    {
        
    }

    public void selectCharacterById(int id)
    {
        // _selectedCharacter = _characters[id];
        // OnCharacterChange?.Invoke(this, EventArgs.Empty);
        // Debug.Log("Character ID: " + _selectedCharacter.getCharacterId());
        
        foreach (var character in _characters)
        {
            if (character.getCharacterId() == id)
            {
                selectCharacter(character);
                OnCharacterChange?.Invoke(this, EventArgs.Empty);
                Debug.Log("Character ID: " + character.getCharacterId());
            }
        }
    }
    public void selectCharacter(CharacterManager character)
    {
        _selectedCharacter = character;
        Debug.Log(_selectedCharacter.getCharacterName());
        OnCharacterChange?.Invoke(this, EventArgs.Empty);
        Debug.Log("Personagem selecionado");
    }

    public void HaldleOnGameStart(object sender, EventArgs e)
    {
        Debug.Log("Jogo começou.");
    }

    public void HaldleOnGameEnd(object sender, EventArgs e)
    {
        Debug.Log("Jogo encerrou.");
    }

    public void HandleOnCallTutorial(object sender, EventArgs e)
    {
        Debug.Log("Tutorial chamado");
    }

    public void restartGame()
    {

    }

    public CharacterManager getSelectedCharacter()
    {
        return _selectedCharacter;
    }
    
    public void OnDestroy()                                                                                                                                                                                                       
    {

    }
}
