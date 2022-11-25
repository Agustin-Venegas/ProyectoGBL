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
            File.WriteAllText(path, "SavedGameData \n\n");
        }
    }

    public void Start()
    {
        CreateDataFile();
        SaveInfo("Pichula" +
            " wena conchetumare" +
            " probando probando");
        LoadInfo();
    }

    public void SaveInfo(string infoToSave)
    {
        File.AppendAllText(path, infoToSave);
    }

    public void LoadInfo()
    {
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

}
