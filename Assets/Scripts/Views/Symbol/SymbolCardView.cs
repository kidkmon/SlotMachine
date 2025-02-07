using UnityEngine;
using UnityEngine.UI;

public class SymbolCardView : View<SymbolCardViewController, SymbolCardView>
{
    [SerializeField] Image _icon;

    SymbolAssetConfig _config;
    
    public void Setup(SymbolAssetConfig config){
        _config = config;
        _icon.sprite = config.Icon;
    }

    public SymbolAssetConfig GetConfig(){
        return _config;
    }
}
