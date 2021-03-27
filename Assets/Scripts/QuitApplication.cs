using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void QuitApp()
    {
        Debug.Log("Application has quit");
        Application.Quit();
    }
}
