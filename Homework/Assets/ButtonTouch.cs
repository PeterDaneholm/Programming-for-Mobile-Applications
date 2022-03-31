using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

//I did not figure out a way for the input system to only be activited by pressing the button, nor did I figure out
//how or why it would not add any values to my list, even when changing the values to constant numbers.
//Because of reoccuring problems with my phone, it did not allow me to test the app to check if it actually
//activated the accelerometer. These were just a few of the problems I encountered with this assignment.

public class ButtonTouch : MonoBehaviour
{
    private TouchControls touchControls;

    string filename = "";

    private bool isPressed = false;

    [System.Serializable]
    public class sensorData
    {
        public Vector3 accelData;
    }

    [System.Serializable]
    public class DataList
    {
        public sensorData[] data;
    }

    public DataList AccelInfo = new DataList();

    List<Vector3> AccelInfoList = new List<Vector3>();
    //From provided tutorials
    private void Awake()
    {
        touchControls = new TouchControls();
        InputSystem.EnableDevice(Accelerometer.current);
    }
    //From provided tutorials
    private void OnEnable()
    {
        touchControls.Enable();
    }
    //From provided tutorials
    private void Start()
    {
        //For PC connection
        filename = Application.dataPath + "/test.csv";
        //For Android phones (https://forum.unity.com/threads/write-data-from-list-to-csv-file.643561/)
        //filename = Application.persistentDataPath + "/test.csv";
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
    }

    public void WriteCSV()
    {
        if (AccelInfoList.Count >= 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine(AccelInfoList);
            tw.Close();

            tw = new StreamWriter(filename, true);
            tw.WriteLine(AccelInfoList + ";");
            tw.Close();
            Debug.Log("Test 3");
        }
        Debug.Log("Test 2");
    }

    private void Update()
    {
        //same reference as above the method
        //Vector3 accelValue = preciseAccelValue();

        if(isPressed == true)
        {
            isPressed = false;
        }

    }

    //code from https://riptutorial.com/unity3d/example/12420/read-accelerometer-sensor-precision- 
    Vector3 preciseAccelValue()
    {
        Vector3 accelResult = Vector3.zero;
        for (int i = 0; i < Input.accelerationEventCount; ++i)
        {
            AccelerationEvent tempAccelEvent = Input.GetAccelerationEvent(i);
            accelResult = accelResult + (tempAccelEvent.acceleration * tempAccelEvent.deltaTime);
        }
        return accelResult;
    }

    //Method from provided tutorial, which have been modified to call the WriteCSV method, and add the accelerometer info to the list. 
    private void StartTouch(InputAction.CallbackContext context)
    {
        if (isPressed == false)
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
        Vector3 accelValue = preciseAccelValue();
        AccelInfoList.Add(accelValue);
        Debug.Log("test");
        WriteCSV();

    }
}
