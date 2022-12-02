using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    string path;

    public void CreateDataFile()
    {
        path = Application.dataPath + "/saveGameData.txt";

        if (!File.Exists(path))
        {
            //File.WriteAllText(path, "SavedGameData \n\n");
        }
    }

    public void Start()
    {
        CreateDataFile();
       
        SaveInfo(" a"," b"," c"," d");
        LoadInfo();
    }

    public void SaveInfo(string A, string B, string C, string D)
    {
        List<string> infoSave = new List<string>();
        infoSave.Add(A);
        infoSave.Add(B);
        infoSave.Add(C);
        infoSave.Add(D);
        File.WriteAllLines(path,infoSave);

    }

    public void LoadInfo()
    {
        StreamReader reader = new StreamReader(path);
        string LoadedInfo = reader.ReadToEnd();
        var SplitInfo = LoadedInfo.Split(' ');

        foreach(var Info in SplitInfo)
        {
            Debug.Log(Info);
        }

        reader.Close();
    }

    public void DeleteInfo()
    {
        File.Delete(path);
    }

}
