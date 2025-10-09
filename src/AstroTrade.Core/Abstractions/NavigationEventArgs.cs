namespace AstroTrade.Core.Abstractions;

public class NavigationEventArgs : EventArgs
{
    public string Target { get; }
    public object? Parameter { get; }

    public NavigationEventArgs(string target, object? parameter = null)
    {
        Target = target;
        Parameter = parameter;
    }
}