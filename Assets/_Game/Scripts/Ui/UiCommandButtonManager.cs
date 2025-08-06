using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private CommandType buttonCommandTypeId;

    private CharacterManager _CharacterManager;

    void Awake()
    {
        _CharacterManager = GetComponent<CharacterManager>();
    }

    public void OnClick()
    {
        AddClickedCommandToList();
    }
    
    public void AddClickedCommandToList()
    {
        _CharacterManager.AddCommandToList(buttonCommandTypeId);

    }

}
