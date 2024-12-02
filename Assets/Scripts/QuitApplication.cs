using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{  
    void Update()
    {
        QuitGame();
    }
    
    void QuitGame()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
            Debug.Log("escape works");
        }
    }
}
