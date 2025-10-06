using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{
    private GameManager _gameManager;
    private CharacterCommandsExecutor _executor;
    [SerializeField]
    private CharacterData _characterData;

    public CharacterCommandList CommandList {get; private set;} = new CharacterCommandList();

    void Awake()
    {
        _executor =  GetComponent<CharacterCommandsExecutor>();
        _gameManager = GameManager.Instance;
    }

    void Start()
    {
        _gameManager.OnCallCommandListsExecution += GameManager_OnCallCommandListExecution;
    }
    
    public void GameManager_OnCallCommandListExecution(object o, EventArgs eventArgs)
    {
        ExecuteCommandList();
    }

    private void ExecuteCommandList()
    {
        _executor.ExecutorExecuteCommandList(CommandList.MainSequence);
    }
    
    public void AddCommandToList(CommandType command)
    {
        CommandList.MainSequence.Add(command);
        _gameManager.NotifyCommandListChange();
        
    }

    public void RemoveCommandFromList(int commandIndex)
    {
        CommandList.MainSequence.RemoveAt(commandIndex);
        _gameManager.NotifyCommandListChange();
        
    }
    public void countStep()
    {
        _characterData.characterStepsCount++;
    }

    public void ResetStepsCount()
    {
        _characterData.characterStepsCount = 0; 
    }
    public int getCharacterStepsCount()
    {
        return _characterData.characterStepsCount;
    }

    public string getCharacterName()
    {
        return _characterData.characterName;
    }

    public bool getHaveKey()
    {
        return _characterData.hasKey;
    }

    public int getCharacterId()
    {
        return _characterData.characterID;
    }
}
