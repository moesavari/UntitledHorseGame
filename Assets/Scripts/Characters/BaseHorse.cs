using UnityEngine;

public class BaseHorse : MonoBehaviour
{
    #region Enumerator Properties
    public enum HorseType
    {
        DRAFT,
        LIGHT,
        PONY
    }

    public enum DraftHorseBreeds
    {
        Clydesdale,
        Shire,
        Belgian,
        Percheron,
    }

    public enum LightHorseBreeds
    {
        Arabian,
        Thoroughbred,
        QuarterHorse,
        Appaloosa,
    }

    public enum PonyHorseBreeds
    {
        Shetland,
        Welsh,
        Dartmoor,
        Exmoor
    }

    public enum HorseColor
    {
        Black,
        White,
        Brown,
        Grey,
        Chestnut,
        Palomino,
        Pinto,
        Roan
    }

    public enum HorseTemperament
    {
        Social,
        Aloof,
        Fearful,
        Challenging
    }
    #endregion

    public string Name;
    public int Age;
    public int BreedInt;

    public HorseType HorseTyping;

    [HideIfEnumValue("HorseTyping", HideIf.NotEqual, (int)HorseType.DRAFT)]
    public DraftHorseBreeds DraftBreeds;

    [HideIfEnumValue("HorseTyping", HideIf.NotEqual, (int)HorseType.LIGHT)]
    public LightHorseBreeds LightBreeds;

    [HideIfEnumValue("HorseTyping", HideIf.NotEqual, (int)HorseType.PONY)]
    public PonyHorseBreeds PonyBreeds;

    public HorseColor Color;
    public HorseTemperament Temperament;

    public BaseHorse(string name, string age, HorseType type, int breed)
    {
        Name = name;
        Age = int.Parse(age);
        HorseTyping = type;

        switch(HorseTyping)
        {
            case HorseType.DRAFT:
                DraftBreeds = (DraftHorseBreeds)breed;
                break;
            case HorseType.LIGHT:
                LightBreeds = (LightHorseBreeds)breed;
                break;
            case HorseType.PONY:
                PonyBreeds = (PonyHorseBreeds)breed;
                break;
        }
    }

    public void SetupHorseData(BaseHorse horse)
    {
        Name = horse.Name;
        Age = horse.Age;
        HorseTyping = horse.HorseTyping;

        switch(HorseTyping)
        {
            case HorseType.DRAFT:
                DraftBreeds = horse.DraftBreeds;
                BreedInt = (int)DraftBreeds;
                break;
            case HorseType.LIGHT:
                LightBreeds = horse.LightBreeds;
                BreedInt = (int)LightBreeds;
                break;
            case HorseType.PONY:
                PonyBreeds = horse.PonyBreeds;
                BreedInt = (int)PonyBreeds;
                break;
        }
    }
}
