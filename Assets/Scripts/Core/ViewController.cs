public abstract class ViewController<TView>
{
    protected TView View { get; private set; }

    public void Initialize(TView view)
    {
        View = view;
        SetupEventHandlers();
        OnInitialized();
    }

    public virtual void Cleanup()
    {
        RemoveEventHandlers();
    }

    protected abstract void SetupEventHandlers();
    protected abstract void RemoveEventHandlers();
    protected virtual void OnInitialized() { }
}