using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoSingleton<DataController>
{
    private string _saveFilePath;
    private List<HorseData> _horseData;

    //Instanced variables
    private Stable _stableController;

    private void Start()
    {
        _saveFilePath = Application.persistentDataPath + "/StableData.json";

        _stableController = Stable.Instance;
    }

    #region Stable Data Controller
    public void SaveStableeData()
    {
        DeleteStableData();
        ConvertDataToJsonReadable();

        string saveData = JsonConvert.SerializeObject(_horseData, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        });

        File.WriteAllText(_saveFilePath, saveData);

        Debug.Log("Save file created at: " + _saveFilePath);
    }

    public void LoadStableData()
    {
        if (File.Exists(_saveFilePath))
        {
            string loadData = File.ReadAllText(_saveFilePath);
            ConvertJsonToDataReadable(loadData);

            for (int i = 0; i < _stableController.ListOfHorses.Count; i++)
            {
                Debug.Log("Data retrieved for: " + _stableController.ListOfHorses[i].Name);
            }
        }
        else Debug.Log("No save file to load");
    }

    public void DeleteStableData()
    {
        if (File.Exists(_saveFilePath))
        {
            File.Delete(_saveFilePath);

            Debug.Log("Save file deleted");
        }
        else Debug.Log("No save file to delete");
    }
    #endregion

    private void ConvertDataToJsonReadable()
    {
        _horseData = new List<HorseData>();

        for (int i = 0; i < _stableController.ListOfHorses.Count; i++)
        {
            HorseData data = new HorseData
            {
                Name = _stableController.ListOfHorses[i].Name,
                Age = _stableController.ListOfHorses[i].Age,
                Type = _stableController.ListOfHorses[i].HorseTyping,
                Breed = _stableController.ListOfHorses[i].BreedInt
            };

            _horseData.Add(data);
        }
    }

    private void ConvertJsonToDataReadable(string loadData)
    {
        _horseData = JsonConvert.DeserializeObject<List<HorseData>>(loadData);

        for(int i = 0; i <  _horseData.Count; i++)
        {
            BaseHorse horse = new BaseHorse(_horseData[i].Name, 
                                            _horseData[i].Age.ToString(), 
                                            _horseData[i].Type, 
                                            _horseData[i].Breed);

            _stableController.AddHorse(horse);
        }
    }
}

[Serializable]
public class HorseData
{
    public string Name;
    public int Age;
    public BaseHorse.HorseType Type;
    public int Breed;
}