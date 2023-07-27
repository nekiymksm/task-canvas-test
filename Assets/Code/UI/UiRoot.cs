using UnityEngine;

public class UiRoot : MonoBehaviour
{
    [SerializeField] private Window[] _windows;

    private void Awake()
    {
        foreach (var window in _windows)
        {
            window.Init(this);
        }
    }

    public T GetWindow<T>() where T : Window
    {
        for (int i = 0; i < _windows.Length; i++)
        {
            if (_windows[i].GetType() == typeof(T))
            {
                return _windows[i] as T;
            }
        }

        Debug.LogError("WINDOW_NOT_FOUND");
        return null;
    }
}