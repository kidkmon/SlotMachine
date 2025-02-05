
public class SlotMachineViewController : ViewController<SlotMachineView>
{
    protected override void OnInitialized()
    {
        for (int i = 0; i < EnvironmentConfigs.Instance.GameConfig.ReelsCount; i++)
        {
            View.AddReelColumnView();
        }
    }

    protected override void SetupEventHandlers()
    {
        View.SpinButton.onClick.AddListener(OnSpinButtonClicked);
    }
    protected override void RemoveEventHandlers()
    {
        View.SpinButton.onClick.RemoveListener(OnSpinButtonClicked);
    }

    void OnSpinButtonClicked()
    {
        foreach (var reelColumnView in View.ReelColumnViews)
        {
            //TODO: Implement spinning logic
        }
    }
}