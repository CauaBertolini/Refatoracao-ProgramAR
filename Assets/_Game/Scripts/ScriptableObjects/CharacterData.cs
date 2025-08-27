using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    [Header("Identificação")]
    public string characterName;
    public int characterID;

    [Header("Estado do Personagem")]
    public bool hasKey;
    public bool isDead;
    public bool hasFinishCommandsExecution;
    public int characterStepsCount;
}
