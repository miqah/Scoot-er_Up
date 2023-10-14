using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDialog : MonoBehaviour
{   
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] Text helpMessageTextBox;
    [SerializeField] string dialog;
    [SerializeField] string helpMessage;
    public bool inRange;

    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            if(dialogBox.activeInHierarchy)
            {    
                dialogBox.SetActive(false);
                dialogText.text = "";
            } 
            
            else 
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                helpMessageTextBox.text = "";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
            helpMessageTextBox.text = helpMessage;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = false;
            dialogBox.SetActive(false);
            helpMessageTextBox.text = "";
            dialogText.text = "";
        }
    }
}
