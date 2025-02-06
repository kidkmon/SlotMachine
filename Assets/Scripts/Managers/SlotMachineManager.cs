using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SlotMachineManager : Singleton<SlotMachineManager>
{
    [SerializeField] List<GameObject> _slotMachines;

    [HideInInspector] public UnityEvent OnActivateSlotMachine;
    [HideInInspector] public UnityEvent OnRemoveSlotMachine;

    int _slotMachinesMaxInstances;
    
    void Start()
    {
        _slotMachinesMaxInstances = EnvironmentConfigs.Instance.GameConfig.SlotMachinesMaxInstances;

        PlayerPrefs.SetInt("SlotMachineInstances", 1);
        ActivateSlotMachines();
    }

    void ActivateSlotMachines()
    {
        for (int i = 0; i < _slotMachines.Count; i++)
        {
            if (!_slotMachines[i].activeSelf)
            {
                _slotMachines[i].SetActive(true);
                break;
            }
        }
        OnActivateSlotMachine?.Invoke();
    }

    void DisableSlotMachine()
    {
        for (int i = 0; i < _slotMachines.Count; i++)
        {
            if (_slotMachines[i].activeSelf)
            {
                _slotMachines[i].SetActive(false);
                break;
            }
        }
        OnRemoveSlotMachine?.Invoke();
    }

    int GetActiveSlotMachineInstances() => Math.Min(PlayerPrefs.GetInt("SlotMachineInstances", 1), _slotMachinesMaxInstances); // Ensure max instances

    #region Public Methods

    public void IncreaseSlotMachineInstances()
    {
        var activeInstances = GetActiveSlotMachineInstances();
        var instances = Math.Min(activeInstances + 1, _slotMachinesMaxInstances); // Ensure max instances
        ActivateSlotMachines();
        PlayerPrefs.SetInt("SlotMachineInstances", instances);
    }

    public void DecreaseSlotMachineInstances()
    {
        var activeInstances = GetActiveSlotMachineInstances();

        if (activeInstances > 1)
        {
            var instances = Math.Max(activeInstances - 1, 1); // Ensure at least one instance is active
            DisableSlotMachine();
            PlayerPrefs.SetInt("SlotMachineInstances", instances);
        }
    }

    public IEnumerable<SlotMachineView> GetActiveSlotMachines()
    {
        return _slotMachines.Where(slotMachine => slotMachine.activeSelf).Select(slotMachine => slotMachine.GetComponent<SlotMachineView>());
    }

    #endregion
}
