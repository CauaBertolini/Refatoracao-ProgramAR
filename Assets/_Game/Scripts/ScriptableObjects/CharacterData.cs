using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
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
