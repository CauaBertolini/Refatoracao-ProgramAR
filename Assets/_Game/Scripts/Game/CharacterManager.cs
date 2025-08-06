using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    
    private bool _isDead;
    private bool _hasFinishedCommandExecution;
    private int characterStepsCount;
    private bool _haveKey;

    [SerializeField]
    private int _characterID;

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
        return characterStepsCount;
    }

    public void countStep()
    {
        characterStepsCount++;
    }

    public void ResetStepsCount()
    {
        characterStepsCount = 0;
    }

    public bool getHaveKey()
    {
        return _haveKey;
    }
}
