using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string namePlayer;
    public string namePlayerHighScore;
    public int highScore = 0;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDataPlayer();
    }
    
    [System.Serializable]
    class SaveData
    { 
        public string namePlayerHighScore;
        public int highScore;
    }

    public void SaveDataPlayer()
    {
        SaveData data = new SaveData();
        data.namePlayerHighScore = namePlayerHighScore;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadDataPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            namePlayerHighScore = data.namePlayerHighScore;
        }
    }
}
