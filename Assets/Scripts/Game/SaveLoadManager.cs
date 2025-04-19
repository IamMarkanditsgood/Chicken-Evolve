using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static SaveLoadManager;

public class SaveLoadManager : MonoBehaviour
{
    private static string SavePath => Application.persistentDataPath + "/save.json";

    public static void SaveChickens(List<MergeChicken> chickens)
    {
        List<ChickenSaveData> dataList = new List<ChickenSaveData>();

        foreach (var chick in chickens)
        {
            Vector2 pos = chick.transform.position;
            dataList.Add(new ChickenSaveData(chick.Level, pos));
        }

        string json = JsonUtility.ToJson(new ChickenSaveWrapper(dataList));
        File.WriteAllText(SavePath, json);
    }

    public static List<ChickenSaveData> LoadChickens()
    {

        if (!File.Exists(SavePath)) return null;

        string json = File.ReadAllText(SavePath);
        ChickenSaveWrapper wrapper = JsonUtility.FromJson<ChickenSaveWrapper>(json);

        return wrapper?.Chickens ?? new List<ChickenSaveData>();
    }

    [System.Serializable]
    private class ChickenSaveWrapper
    {
        public List<ChickenSaveData> Chickens;

        public ChickenSaveWrapper(List<ChickenSaveData> chickens)
        {
            Chickens = chickens;
        }
    }
}
