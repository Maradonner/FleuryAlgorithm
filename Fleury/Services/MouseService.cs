using Microsoft.AspNetCore.Components.Web;

namespace Fleury.Services;

public interface IMouseService
{
    event EventHandler<MouseEventArgs>? OnMove;
    event EventHandler<MouseEventArgs>? OnUp;
    event EventHandler<MouseEventArgs>? OnLeave;
    event EventHandler<MouseEventArgs>? OnClick;
    event EventHandler<MouseEventArgs>? OnContextMenu;
}

public class MouseService : IMouseService
{
    public event EventHandler<MouseEventArgs>? OnMove;
    public event EventHandler<MouseEventArgs>? OnUp;
    public event EventHandler<MouseEventArgs>? OnLeave;
    public event EventHandler<MouseEventArgs>? OnClick;
    public event EventHandler<MouseEventArgs>? OnContextMenu;

    public void FireMove(object obj, MouseEventArgs evt) => OnMove?.Invoke(obj, evt);
    public void FireUp(object obj, MouseEventArgs evt) => OnUp?.Invoke(obj, evt);
    public void FireLeave(object obj, MouseEventArgs evt) => OnLeave?.Invoke(obj, evt);
    public void FireClick(object obj, MouseEventArgs evt) => OnClick?.Invoke(obj, evt);
    public void FireContextMenu(object obj, MouseEventArgs evt) => OnContextMenu?.Invoke(obj, evt);
}

