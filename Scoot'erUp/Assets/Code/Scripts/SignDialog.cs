using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDialog : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] Text helpMessageTextBox;
    private string dialog = "To halt your slide, tap 'S' on your trusty keyboard.\n\nUse your nimble mouse to drag and aim.\n\nReady? Release the button to propel yourself upward into the sky!\n\n\t\t\t\t\tPress The Space Key to Close the Menu";
    private string helpMessage = "Press Space to Interact";
    public bool inRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            if (dialogBox != null)
            {
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    ClearText(dialogText);
                }
                else
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    ClearText(helpMessageTextBox);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
            helpMessageTextBox.text = helpMessage;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            if (dialogBox != null)
            {
                dialogBox.SetActive(false);
            }
            ClearText(dialogText);
            ClearText(helpMessageTextBox);
        }
    }

    private void ClearText(Text textComponent)
    {
        if (textComponent != null)
        {
            textComponent.text = "";
        }
    }
}






