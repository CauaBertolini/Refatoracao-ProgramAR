using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UiMenuManager : MonoBehaviour
{
    public void LoadLevel(String levelName)
    {
        if (string.IsNullOrEmpty(levelName))
        {
            Debug.LogError("Nome não pode ser vazio ou nulo.");
            return;
        }

        try
        {
            SceneManager.LoadScene(levelName);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro ao tentar carregar '{levelName}': {ex.Message}");
        }
    }

}
