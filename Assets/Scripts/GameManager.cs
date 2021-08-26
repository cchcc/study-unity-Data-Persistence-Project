using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Serializable]
    public class GameData
    {
        public string playerName = "";
        public string highScoredName = "";
        public int highScore = 0;
    }

    public GameData data;

    private string dataPath;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
        dataPath = $"{Application.persistentDataPath}/data.json";
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, json);
        Debug.Log($"saved: {dataPath}");
    }

    public void LoadData()
    {
        if (File.Exists(dataPath))
        {
            var json = File.ReadAllText(dataPath);
            data = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            data = new GameData();
        }
    }

    public void ClearData()
    {
        File.Delete(dataPath);
        data = new GameData();
    }
}
