using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public string PlayerName;

    public int HighScore;
    public string HighScoreName;

    public static MainManager Instance;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScoreName;
    }

    public void SaveHighScore(string name, int score)
    {
        SaveData data = new SaveData();
        HighScore = score;
        HighScoreName = name;
        data.HighScore = score;
        data.HighScoreName = name;
        string data_json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", data_json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string data_json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(data_json);
            HighScore = data.HighScore;
            HighScoreName = data.HighScoreName;
        }

    }
}
