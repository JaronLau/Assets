using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    /// <summary>
    /// sets game object for instruction UI
    /// </summary>
    public GameObject menu;
    
    /// <summary>
    /// function to close instruction UI
    /// </summary>
    public void closeMenu()
    {
        menu.SetActive(false);
    }

    /// <summary>
    /// on key press, run function
    /// </summary>
    void OnUI()
    {
        closeMenu();
    }

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
