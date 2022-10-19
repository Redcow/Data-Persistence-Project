using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstanceManager : MonoBehaviour
{
    public static InstanceManager Instance;
    [SerializeField] TMP_Text bestScoreTxt;
    private PlayerClass bestPlayer;

    private PlayerClass player;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        player = new PlayerClass();
        LoadBestScores();
        displayBestScore(bestScoreTxt);
    }

    public PlayerClass GetPlayer()
    {
        return player;
    }

    public void SetPlayerName(string _playerName)
    {
        player.name = _playerName;
    }

    public string GetPlayerName()
    {
        return player.name;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public bool UpdateScore()
    {
        if (player.score > bestPlayer.score)
        {
            bestPlayer = new PlayerClass(player.name, player.score);
            SaveData data = new SaveData();
            data.bestScore = player.score;
            data.playerName = player.name;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            return true;
        }
        return false;
    }

    public void LoadBestScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = new PlayerClass(data.playerName, data.bestScore);
        }
        else
        {
            bestPlayer = new PlayerClass();
        }
    }

    public PlayerClass GetBestPlayer()
    {
        return bestPlayer;
    }

    public void displayBestScore(Text textBox)
    {
        if(bestPlayer.name != "")
        {
            textBox.text = $"{bestPlayer.name} : {bestPlayer.score}pts";
        } else {
            textBox.text = "";
        }
    }

    public void displayBestScore(TMP_Text textBox)
    {
        if(bestPlayer.name != "")
        {
            textBox.text = $"{bestPlayer.name} : {bestPlayer.score}pts";
        } else {
            textBox.text = "";
        }
    }
}
