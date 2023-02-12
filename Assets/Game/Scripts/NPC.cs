using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index = listened ? 2 : 0;
    static private bool gotKPD = false;
    static private bool listened = false;
    //private bool asd = true;
    private uint kpd = 12;

    public Image gun = null;
    public Text KPDText = null;
    public Image img;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    private bool asd;
    // Update is called once per frame
    void Update()
    {
         asd = gun.enabled;
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose) 
        { 
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        if (asd)
        { index = 4; }
        else if (listened)
        { index = 2; }
        else
        { index = 0; }
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        
        contButton.SetActive(false);
        if(index < dialogue.Length -1)
        {
            if(!gotKPD)
            {
                kpd = UInt32.Parse(KPDText.text);
                kpd += 1;
                KPDText.text = kpd.ToString();
            }
            //if (!listened && gun.fillAmount != 1f && index !> 5)
            //{
            //    index++;
            //    dialogueText.text = "";
            //    StartCoroutine(Typing());
            //}
            //if (listened && gun.fillAmount != 1f && index !> 5)
            //{
            //    index++;
            //    dialogueText.text = "";
            //    StartCoroutine(Typing());
            //}


            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            gotKPD = true;
            listened = true;
            
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose= true;
            img.fillAmount = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            img.fillAmount = 0f;
            zeroText();
        }
    }
}
