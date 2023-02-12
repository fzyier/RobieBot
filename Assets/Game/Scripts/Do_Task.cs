using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Do_Task : MonoBehaviour
{
    [SerializeField] private Text KPDText = null;
    [SerializeField] private GameObject obj = null;
    [SerializeField] public Image img = null;
    [SerializeField] public Image gun = null;
    [SerializeField] private int valueOfKPD = 0;
    [SerializeField] private uint SumOfKPD = 12;
    [SerializeField] private bool IsAddKPD = false;
    public AudioClip hurtSound;

    [SerializeField] AudioSource audioSource;

    private bool here = false;
    private uint kpd = 0;
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && here)
        {
            if (audioSource != null)
            {
                audioSource.playOnAwake = true;
                audioSource.Play();
            }

            Destroy(obj);


            if (KPDText != null)
            {
                kpd = UInt32.Parse(KPDText.text);
                if(IsAddKPD) { kpd += SumOfKPD; }
                
                KPDText.text = kpd.ToString();
            }
            if(gun != null)
            {
                gun.enabled = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        kpd = UInt32.Parse(KPDText.text);
        if (collision.gameObject.name == "Player" && kpd >= valueOfKPD)
        {
            img.fillAmount= 1;
            here = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        kpd = UInt32.Parse(KPDText.text);
        if (collision.gameObject.name == "Player" && kpd >= valueOfKPD)
        {
            img.fillAmount = 0f;
            here = false;
        }
    }
}
