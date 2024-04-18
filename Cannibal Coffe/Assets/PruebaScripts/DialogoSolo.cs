using System.Collections;
using System.Diagnostics;
using UnityEngine;
using TMPro;


public class DialogoSolo : MonoBehaviour
{
    //variables
    public TextMeshProUGUI dialogueText;
    public GameObject Panel;
    public string[] lines;
    public float textSpeed = 0.1f;
    int index;
    private void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if ( (dialogueText.text == lines[index]))
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];   
            }
        }
    }
    public void StartDialogue()
    {
        index = 0;
        Panel.SetActive(true);
        StartCoroutine(WriteLine());

    }

    IEnumerator WriteLine()
    {
        foreach (var letter in lines[index].ToCharArray()) {
            dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1) 
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
            Panel.SetActive(false);
        }
    }

}