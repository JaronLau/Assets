using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchscene : MonoBehaviour
{

    static bool sceneSwitcher = false;

    public void Interact()
    {
        if(sceneSwitcher == false)
        {
            SceneManager.LoadScene(1);
            sceneSwitcher = true;
        }
        else if (sceneSwitcher == true)
        {
            SceneManager.LoadScene(0);
            sceneSwitcher=false;
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Interact();
        }
    }
}
