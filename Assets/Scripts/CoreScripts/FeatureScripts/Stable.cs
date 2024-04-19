using System.Collections.Generic;
using UnityEngine;

public class Stable : MonoSingleton<Stable>
{
    public List<BaseHorse> ListOfHorses = new List<BaseHorse>();
    public List<HorseSpawner> ListOfSpawners = new List<HorseSpawner>();

    public GameObject HorsePrefab;

    //Instanced variables
    private DataController _dataController;

    private void Start()
    {
        _dataController = DataController.Instance;
        _dataController.LoadStableData();
    }

    private void OnApplicationQuit()
    {
        _dataController.SaveStableeData();
    }

    public void AddHorse(BaseHorse horse)
    {
        for(int i = 0; i < ListOfSpawners.Count; i++)
        {
            if (!ListOfSpawners[i].IsOccupied)
            {
                GameObject obj = Instantiate(HorsePrefab, ListOfSpawners[i].transform);
                BaseHorse horseObj = obj.GetComponent<BaseHorse>();
                horseObj.SetupHorseData(horse);

                ListOfHorses.Add(horseObj);
                ListOfSpawners[i].IsOccupied = true;
                break;
            }
        }
    }
}
