using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoDetenido : MonoBehaviour
{
    //variables
    public TextMeshProUGUI dialogueText;
    public GameObject Panel;
    public string[] lines;
    public float textSpeed = 0.1f;
    int index;
    private bool didDialogueStart;
    private void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if ((dialogueText.text == lines[index]))
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
        didDialogueStart = true;
        index = 0;
        Panel.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(WriteLine());

    }

    IEnumerator WriteLine()
    {
        foreach (var letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
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
            didDialogueStart = false;
            gameObject.SetActive(false);
            Panel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}