using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoSingleton<GlobalVariables>
{
    public List<string> HorseTypes = new List<string> { "Draft", "Light", "Pony" };
    public List<string> DraftBreeds = new List<string> { "Clydesdale", "Shire", "Belgian", "Percheron" };
    public List<string> LightBreeds = new List<string> { "Arabian", "Thoroughbred", "Quarter Horse", "Appaloosa" };
    public List<string> PonyBreeds = new List<string> { "Shetland", "Welsh", "Dartmoor", "Exmoor" };
}
