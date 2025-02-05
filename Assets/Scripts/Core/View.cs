using UnityEngine;

public abstract class View<TViewController, TView> : MonoBehaviour 
    where TViewController : ViewController<TView>, new()
    where TView : View<TViewController, TView>
{
    private TViewController _controller;

    protected virtual void Start()
    {
        _controller = new TViewController();
        _controller.Initialize((TView)this);
    }

    protected virtual void OnDestroy()
    {
        _controller?.Cleanup();
    }
}