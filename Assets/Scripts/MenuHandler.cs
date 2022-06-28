using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text bestRecordText;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateBestRecord();

        if (DataManager.Instance.playerName != null)
            inputField.text = DataManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBestRecord()
    {
        if(DataManager.Instance.highestScore != 0)
        {
            bestRecordText.text = "Best Score: " + DataManager.Instance.highestScoreOwner + " : " + DataManager.Instance.highestScore;
        }
    }

    public void InputPlayerName()
    {
        DataManager.Instance.playerName = inputField.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveGame();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
