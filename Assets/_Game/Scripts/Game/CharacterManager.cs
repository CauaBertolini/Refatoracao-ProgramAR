using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    
    private bool _isDead;
    private bool _hasFinishedCommandExecution;
    public int CharacterStepsCount;
    public bool _haveKey {get; private set;}

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

    public void RemoveCommandFromList()
    {

    }

    public void CharacterStepsCounter()
    {
        CharacterStepsCount++;
    }
}
