using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject characterSelected;

    private int levelType = 0;
    private int levelID { get; set; } = 0;
    private int higherUnlockedLevel { get; set; } = 0;

    public event Action OnGameStart;
    public event Action OnGameEnd;
    public event Action OnCallTutorial;
    public event Action OnCallCommandListsExecution;

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
        
        OnGameStart += HaldleOnGameStart;
        OnGameEnd += HaldleOnGameEnd;
        OnCallTutorial += HandleOnCallTutorial;

    }

    void Update()
    {
        
    }

    public void HaldleOnGameStart()
    {
        Debug.Log("Jogo começou.");
    }

    public void HaldleOnGameEnd()
    {
        Debug.Log("Jogo encerrou.");
    }

    public void HandleOnCallTutorial()
    {
        Debug.Log("Tutorial chamado");
    }

    public void restartGame()
    {

    }
    
    public void OnDestroy()                                                                                                                                                                                                       
    {

    }
}
