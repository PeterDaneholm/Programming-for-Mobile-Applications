using UnityEngine;
using UnityEngine.InputSystem;

//From provided tutorial
[DefaultExecutionOrder(-1)]
public class InputManager : SingletonClass<InputManager>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    //public delegate void EndTouchEvent(Vector2 position, float time);
    //public event EndTouchEvent OnEndTouch;

    //HUSK DET ER NAVNET PÅ INPUTACTION CONTROLLEREN
    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        //touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

   /* private void EndTouch (InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);

    }*/
}
