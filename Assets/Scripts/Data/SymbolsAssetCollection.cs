using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SymbolsAssetCollection : ScriptableObject
{
    [SerializeField] SymbolAssetConfig[] SymbolAssetConfigs;

    Dictionary<int, SymbolAssetConfig> _symbolAssetConfigs;

    public int Size => SymbolAssetConfigs.Length;

    public void Initialize()
    {
        _symbolAssetConfigs = new Dictionary<int, SymbolAssetConfig>();
        foreach (var config in SymbolAssetConfigs)
        {
            _symbolAssetConfigs.Add(config.Id, config);
        }
    }

    public SymbolAssetConfig GetConfig(int id)
    {
        return _symbolAssetConfigs[id];
    }
}