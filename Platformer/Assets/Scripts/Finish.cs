using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool LevelDone = false;
   private void Start()
    {

        finishSound = GetComponent<AudioSource>();  

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !LevelDone)
        {
            finishSound.Play();
            LevelDone = true;   
            Invoke("CompleteLevel", 2f);
           
            //player done goes up 
        }
    }

    private void CompleteLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //index goes up 


    }

}
