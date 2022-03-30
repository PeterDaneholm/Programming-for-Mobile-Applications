using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonTakeTwo : MonoBehaviour
{
    [System.Serializable]
    public class InfoStream
    {
        public float fuckoff;

    }

    private List<InfoStream> Information = new List<InfoStream>();

    private TouchControls touchControls;

    string filename = "";


    // Start is called before the first frame update
    void Awake()
    {
        InputSystem.EnableDevice(Accelerometer.current);
        touchControls = new TouchControls();
    }

    private void Start()
    {
        //filename = Application.dataPath + "/test.csv";

    }

    // Update is called once per frame
    void Update()
    {
        var acceleration = Accelerometer.current.acceleration.ReadValue();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        
        Debug.Log(Accelerometer.current.acceleration.ReadValue());
    }
}
