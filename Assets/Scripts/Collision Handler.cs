using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    
        private void OnCollisionEnter(Collision other) 
        {
            switch(other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("all good");
                    break;
                case "Finish":
                    LoadNextLevel();
                    break;
                case "Fuel":
                    Debug.Log("fuel added");
                    break;
                default:
                    ReloadLevel();
                    break;
            }
        }
    
    
    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if(nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    

    
}
