using TMPro;
using UnityEngine;

public class StableMenu : MonoSingleton<StableMenu>
{
    [Header("TMP Objects")]
    [SerializeField] private TextMeshProUGUI _nameTMP;
    [SerializeField] private TextMeshProUGUI _ageTMP;
    [SerializeField] private TextMeshProUGUI _breedTMP;

    [Header("UI Objects")]
    [SerializeField] private GameObject _mainStableUI;
    [SerializeField] private GameObject _addHorseUI;

    [Header("Add Horse UI")]
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TMP_InputField _ageInput;
    [SerializeField] private TMP_Dropdown _horseTypeDropdown;
    [SerializeField] private TMP_Dropdown _breedDropdown;

    private int _currentSelectedHorse;

    //Instanced variables
    private Stable _stableController;
    private GlobalVariables _globalVariables;

    private void OnEnable()
    {
        _stableController = Stable.Instance;
        _globalVariables = GlobalVariables.Instance;

        StartWithMainUI();

        if (_stableController.ListOfHorses.Count > 0)
        {
            UpdateHorseInfo(Stable.Instance.ListOfHorses[0]);
        }
        else
        {
            SetFieldsEmpty();
        }

        _currentSelectedHorse = 0;

        _horseTypeDropdown.ClearOptions();
        _horseTypeDropdown.AddOptions(_globalVariables.HorseTypes);
        HorseTypeDropdownValueChanged(_horseTypeDropdown);

        _horseTypeDropdown.onValueChanged.AddListener(delegate { HorseTypeDropdownValueChanged(_horseTypeDropdown); });
    }

    private void OnDisable()
    {
        _horseTypeDropdown.onValueChanged.RemoveAllListeners();
    }

    private void HorseTypeDropdownValueChanged(TMP_Dropdown horseTypeDropdown)
    {
        _breedDropdown.ClearOptions();

        switch (horseTypeDropdown.value)
        {
            case 0:
                _breedDropdown.AddOptions(_globalVariables.DraftBreeds);
                break;
            case 1:
                _breedDropdown.AddOptions(_globalVariables.LightBreeds);
                break;
            case 2:
                _breedDropdown.AddOptions(_globalVariables.PonyBreeds); 
                break;
        }
    }

    public void UpdateHorseInfo(BaseHorse horseInfo)
    {
        _nameTMP.text = horseInfo.Name;
        _ageTMP.text = horseInfo.Age.ToString();
        
        switch (horseInfo.HorseTyping)
        {
            case BaseHorse.HorseType.DRAFT:
                _breedTMP.text = horseInfo.DraftBreeds.ToString();
                break;
            case BaseHorse.HorseType.LIGHT:
                _breedTMP.text = horseInfo.LightBreeds.ToString();
                break;
            case BaseHorse.HorseType.PONY:
                _breedTMP.text = horseInfo.PonyBreeds.ToString();
                break;
        }
    }

    public void SetFieldsEmpty()
    {
        _nameTMP.text = "NA";
        _ageTMP.text = "NA";
        _breedTMP.text = "NA";
    }

    private void StartWithMainUI()
    {
        _mainStableUI.SetActive(true);
        _addHorseUI.SetActive(false);
    }

    #region Button Functions

    public void ShowNextHorse()
    {
        _currentSelectedHorse++;
        if (_currentSelectedHorse >= _stableController.ListOfHorses.Count)
        {
            _currentSelectedHorse = 0;
        }

        UpdateHorseInfo(_stableController.ListOfHorses[_currentSelectedHorse]);
    }

    public void ShowPreviousHorse()
    {
        _currentSelectedHorse--;
        if (_currentSelectedHorse < 0)
        {
            _currentSelectedHorse = _stableController.ListOfHorses.Count - 1;
        }

        UpdateHorseInfo(_stableController.ListOfHorses[_currentSelectedHorse]);
    }

    public void AddHorseButton()
    {
        _mainStableUI.SetActive(false);
        _addHorseUI.SetActive(true);
    }

    public void AddToListButton()
    {
        BaseHorse horse = new BaseHorse(_nameInput.text, 
                                        _ageInput.text, 
                                        (BaseHorse.HorseType)_horseTypeDropdown.value, 
                                        _breedDropdown.value);

        _stableController.AddHorse(horse);

        BackToStableUI();
    }

    public void BackToStableUI()
    {
        _mainStableUI.SetActive(true);
        _addHorseUI.SetActive(false);

        if (_stableController.ListOfHorses.Count > 0)
        {
            UpdateHorseInfo(Stable.Instance.ListOfHorses[0]);
        }
    }

    public void BackToMainMenu()
    {
        CanvasSwap.Instance.SwapToMainMenu();
    }

    #endregion
}
