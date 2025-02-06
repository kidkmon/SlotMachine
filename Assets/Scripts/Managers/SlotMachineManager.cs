using UnityEngine;
using UnityEngine.Events;

public class SlotMachineManager : Singleton<SlotMachineManager>
{
    [SerializeField] GameObject _slotMachinePrefab;
    [SerializeField] Transform _slotMachineParent;

    [HideInInspector] public UnityEvent OnAddSlotMachine;
    [HideInInspector] public UnityEvent OnRemoveSlotMachine;

    void Start()
    {
        var instances = PlayerPrefs.GetInt("SlotMachineInstances", 1);
        for (int i = 0; i < instances; i++)
        {
            AddSlotMachine();
        }
    }

    public void AddSlotMachine()
    {
        Instantiate(_slotMachinePrefab, _slotMachineParent);
        OnAddSlotMachine?.Invoke();
        PlayerPrefs.SetInt("SlotMachineInstances", PlayerPrefs.GetInt("SlotMachineInstances", 1) + 1);
    }

    public void RemoveSlotMachine()
    {
        OnRemoveSlotMachine?.Invoke();
        PlayerPrefs.SetInt("SlotMachineInstances", PlayerPrefs.GetInt("SlotMachineInstances", 1) - 1);
    }
}
