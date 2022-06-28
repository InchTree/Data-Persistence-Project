using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string highestScoreOwner;
    public int highestScore;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    public void UpdateRecord(int score)
    {
        highestScore = score;
        highestScoreOwner = playerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string highestScoreOwner;
        public int highestScore;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highestScore = highestScore;
        data.highestScoreOwner = highestScoreOwner;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestScore = data.highestScore;
            highestScoreOwner = data.highestScoreOwner;
        }
    }
}
