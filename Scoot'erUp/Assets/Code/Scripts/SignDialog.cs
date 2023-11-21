using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SignDialog : MonoBehaviour
{
    [SerializeField]
    GameObject dialogBox;

    [SerializeField]
    Text firstDialogText;

    [SerializeField]
    Text helpMessageTextBox;

    [SerializeField]
    Button nextButton;

    [SerializeField]
    Button backButton;

    private string[] dialogs =
    {   
        "Cuppy, I'm so glad you're here. I'm currently watching the cupball game, and my child is with Mr. Plant. Could you please pick up my kid for me?\n\nWait, you can't recall the controls? No worries, I've got you covered",
        "To halt your slide, tap 'S' on your trusty keyboard.\nUse your nimble mouse to drag and aim.\nReady? Release the button to propel yourself upward into the sky! Good luck!\n\t\t\t\t\tPress The Space Key to Close the Menu",
    };

    private string helpMessage = "Press Space to Interact";
    private int currentDialogIndex = 0;
    public bool inRange;

    void Start()
    {
        UpdateDialogText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            ToggleDialogBox();
        }
    }

    void ToggleDialogBox()
    {
        if (dialogBox != null)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                ClearText(firstDialogText);
            }
            else
            {
                dialogBox.SetActive(true);
                UpdateDialogText();
                ClearText(helpMessageTextBox);
            }
        }
    }

    public void NextDialog()
    {
        currentDialogIndex++;
        if (currentDialogIndex >= dialogs.Length)
        {
            currentDialogIndex = dialogs.Length - 1;
        }
        else
        {
            UpdateDialogText();
        }
    }

    public void PreviousDialog()
    {
        if (currentDialogIndex > 0)
        {
            currentDialogIndex--;
            UpdateDialogText();
        }
    }

    void UpdateDialogText()
    {
        firstDialogText.text = dialogs[currentDialogIndex];
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
            ClearText(firstDialogText);
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
