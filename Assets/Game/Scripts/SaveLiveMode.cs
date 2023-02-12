using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLiveMode : MonoBehaviour
{
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform Pos;

    private GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Enemy = Instantiate(prefab, Pos.position, Panel.transform.rotation);
            Panel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Enemy.SetActive(true);
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Destroy(Dialogue);
            Destroy(Panel, 3f);
        }
    }
}
