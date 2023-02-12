using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{

    [SerializeField] private Collider2D TriggerCollider;
    [SerializeField] private Collider2D outsideCollider;
    [SerializeField] private SpriteRenderer currentSprite;
    [SerializeField] private Sprite changeSpriteTo;
    [SerializeField] private AudioSource ObjectSound;
    [SerializeField] private AudioSource PressedButtonSound;
    [SerializeField] private GameObject pressE;
    [SerializeField] private Text KPDText;
    [SerializeField] private int SumOfKPD = 0;
    [SerializeField] private uint AddingKPD = 12;
    [SerializeField] private bool IsAddKPD = false;

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
            ObjectSound.Play();

            if (KPDText != null)
            {
                kpd = UInt32.Parse(KPDText.text);
                if (IsAddKPD) { kpd += AddingKPD; }

                KPDText.text = kpd.ToString();
            }
            TriggerCollider.enabled = false;
            outsideCollider.enabled = false;
            currentSprite.sprite = changeSpriteTo;
            currentSprite.sortingOrder = 1;
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
