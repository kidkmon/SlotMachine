
public class SymbolCardViewController : ViewController<SymbolCardView>
{
    private SymbolAssetConfig _config;

    public void Initialize(){
        _config = View.GetConfig();
    }

    public int GetSymbolId(){
        return _config.Id;
    }

    public int GetSymbolPayout(){
        return _config.Payout;
    }

    protected override void SetupEventHandlers(){}
    protected override void RemoveEventHandlers(){}
}
