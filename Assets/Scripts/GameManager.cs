using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    MainManager mainManager;

    [SerializeField] GameObject nameField;
    [SerializeField] GameObject afterNameEntered;
    [SerializeField] Text enteredNameText;
    [SerializeField] Text thanksText;

    public string highScorerName;
    public string enteredName;

    public int highScorerPoints;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);        
    }

  public void OnNameEntered()
    {
        enteredName = enteredNameText.text;
        nameField.SetActive(false);
        afterNameEntered.SetActive(true);
        thanksText.text = "Thank you, " + enteredName + "! Lets play?";
    }

  public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]

    public class SaveData
    {
        public string highScoreName;
        public int highScorePoints;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highScoreName = enteredName;
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        data.highScorePoints = mainManager.m_Points;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/Save.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/Save.json", json;

        if (File.Exists(path))
        {
            string jsonTwo = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonTwo);
            highScorerName = data.highScoreName;
            highScorerPoints = data.highScorePoints;
        }
    }
}
