using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    [SerializeField] private Text KPDText;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D TriggerCollider;
    [SerializeField] private GameObject pressE;
    [SerializeField] private int SumOfKPD = 0;
    [SerializeField] private uint AddingKPD = 12;
    [SerializeField] private bool IsAddKPD = false;

    [SerializeField] AudioSource PressedButtonSound;
    [SerializeField] AudioSource TrapSound;
    [SerializeField] private Collider2D TrapCollider;

    private bool here = false;
    private uint kpd = 0;
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && here)
        {
            if (KPDText != null)
            {
                kpd = UInt32.Parse(KPDText.text);
                if (IsAddKPD) { kpd += AddingKPD; }

                KPDText.text = kpd.ToString();
            }
            PressedButtonSound.Play();
            TriggerCollider.enabled = false;
            anim.gameObject.SetActive(false);
            TrapCollider.enabled = false;
            TrapSound.enabled = false;
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
