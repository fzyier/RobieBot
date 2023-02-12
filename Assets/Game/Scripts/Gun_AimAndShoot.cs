using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting;
using static System.Net.WebRequestMethods;

public class Gun_AimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private SpriteRenderer robot;
    [SerializeField] private AudioSource soundFire;

    private float timeBtwShots;
    private float StartTimeBtwShots = 0.8f;

    private GameObject bulletInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    // Update is called once per frame
    void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }

    private void HandleGunRotation()
    {

        worldPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;
        
        angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
        
        Vector3 localScale= new Vector3(1f,1f,1f);
        if(angle > 90 || angle < -90)
        {
            bulletSpawnPoint.transform.position = new Vector3(robot.transform.position.x-1.1f, bulletSpawnPoint.transform.position.y, 0f);
            localScale.y = -1f;
            robot.flipX= false;
            
        }
        else
        {
            bulletSpawnPoint.transform.position = new Vector3(robot.transform.position.x + 1.1f, bulletSpawnPoint.transform.position.y, 0f);
            localScale.y = 1f;
            robot.flipX = true;
        }
        gun.transform.localScale     = localScale;
    }

    private void HandleGunShooting()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!robot.flipX && worldPosition.x < robot.transform.position.x + 2)
                {
                    bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
                    soundFire.Play();
                    timeBtwShots = StartTimeBtwShots;
                }
                else if(robot.flipX && worldPosition.x > robot.transform.position.x - 2)
                {
                    bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
                    soundFire.Play();
                    timeBtwShots = StartTimeBtwShots;
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
