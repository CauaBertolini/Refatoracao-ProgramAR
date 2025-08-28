using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject selectedCharacter;
    private GameManager _gameManager;
    private CharacterCommandsExecutor _executor;

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

    void Update()
    {
        
    }

    public GameObject getCharacterSelected()
    {
        if (selectedCharacter != null) return selectedCharacter;
        else return null;
    }

    public void GameManager_OnCallCommandListExecution()
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
    }

    public void RemoveCommandFromList(CommandType command)
    {
        CommandList.MainSequence.RemoveAt(CommandList.MainSequence.IndexOf(command));
    }

    public int getCharacterStepsCount()
    {
        return 1;
    }   

    public void countStep()
    {
        
    }

    public void ResetStepsCount()
    {

    }

    public bool getHaveKey()
    {
        return false;
    }
}
