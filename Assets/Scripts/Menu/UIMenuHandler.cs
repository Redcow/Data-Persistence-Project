using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuHandler : MonoBehaviour
{
    public void OnNameChange(string _playerName)
    {
        InstanceManager.Instance.SetPlayerName(_playerName);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
