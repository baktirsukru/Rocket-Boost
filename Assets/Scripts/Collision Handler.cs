using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    AudioSource audioSource;

    bool isControllable = true;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(!isControllable) {return;}
        
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("all good");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        
        }

    }

    private void StartSuccessSequence()
    {
        //todo: add particle effect
        isControllable = false;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        successParticle.Play();

        
    }

    private void StartCrashSequence()
    {
        //todo: add particle effect
        isControllable = false;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay); 
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticle.Play();
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
