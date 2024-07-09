using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class InputController 
{
    public event Action<Vector2, bool> OnDirectionChange;

    private SimpleTouchController _simpleTouchController;
    private bool _isTouched;
    private Vector2 _direction;

    public InputController(SimpleTouchController simpleTouchController)
    {
        _simpleTouchController = simpleTouchController;
        _simpleTouchController.TouchEvent += SetDirection ;
        _simpleTouchController.TouchStateEvent += CheckTouchStatus;
    }

    private void CheckTouchStatus(bool touchPresent)
    {
        _isTouched = touchPresent;
    }

    private void SetDirection(Vector2 value)
    {
        _direction = value;

    }
    public void Update() 
    {
        OnDirectionChange?.Invoke(_direction, _isTouched);
    }
}
