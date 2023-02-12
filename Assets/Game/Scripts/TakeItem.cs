using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private Text KPDText;
    [SerializeField] private SpriteRenderer Obj;
    [SerializeField] private Collider2D TriggerCollider;
    [SerializeField] private int SumOfKPD = 0;
    [SerializeField] private uint AddingKPD = 12;
    [SerializeField] private bool IsAddKPD = false;
    [SerializeField] private GameObject pressE;
    [SerializeField] private AudioSource PressedButtonSound;
    [SerializeField] private GameObject Inventory;
    private bool here = false;
    private uint kpd = 0;
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && here)
        {
            PressedButtonSound.Play();

            if (KPDText != null)
            {
                kpd = UInt32.Parse(KPDText.text);
                if (IsAddKPD) { kpd += AddingKPD; }

                KPDText.text = kpd.ToString();
            }

            for (byte i = 0; i < 7; i++)
            {
                if(Inventory.transform.GetChild(i).GetComponentInChildren<Image>().sprite == Obj.sprite)
                {

                }
                if (Inventory.transform.GetChild(i).GetComponentInChildren<Image>().sprite == null)
                {
                    Inventory.transform.GetChild(i).transform.localScale = Obj.transform.localScale;
                    Inventory.transform.GetChild(i).gameObject.GetComponentInChildren<Image>().enabled = true;
                    Inventory.transform.GetChild(i).gameObject.GetComponentInChildren<Image>().sprite = Obj.sprite;
                    break;
                }
            }
            Obj.enabled = false;
            TriggerCollider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        kpd = UInt32.Parse(KPDText.text);
        if (collision.gameObject.name == "Player" && kpd >= SumOfKPD)
        {
            pressE.SetActive(true);
            here = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        kpd = UInt32.Parse(KPDText.text);
        if (collision.gameObject.name == "Player" && kpd >= SumOfKPD)
        {
            pressE.SetActive(false);
            here = false;
        }
    }
}
