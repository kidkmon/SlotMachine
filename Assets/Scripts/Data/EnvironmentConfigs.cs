using UnityEngine;

public class EnvironmentConfigs : MonoBehaviour
{
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] SymbolsAssetCollection _symbolsAssetCollection;

    public static EnvironmentConfigs Instance { get; private set; }
    
    public GameConfig GameConfig => _gameConfig;

    public SymbolsAssetCollection SymbolsAssetCollection => _symbolsAssetCollection;

    private void Awake()
    {
        Instance = this;
        _symbolsAssetCollection.Initialize();
    }
}
