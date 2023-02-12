using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] public Image img = null;
    //private AudioSource finishAudioSource;
    //private bool levelCompleted = false;
    private bool here = false;
    // Start is called before the first frame update
    private void Start()
    {
    //    finishAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(here && Input.GetKeyDown(KeyCode.E))
        {
            Invoke("CompleteLevel", 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
        //    finishAudioSource.Play();
            here= true;
            //levelCompleted = true;
            img.fillAmount = 1f;
            //Invoke("CompleteLevel", 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //    finishAudioSource.Play();
            here = false;
            img.fillAmount = 0f;
            //Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
