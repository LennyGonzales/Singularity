using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject particleBeforeShootPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float countdownBetweenShoot = 2f;

    private float countdownActual;

    void Start() 
    {
        countdownActual = countdownBetweenShoot;    //The player can shots immediately
    }

    void Update() 
    {
        countdownActual += Time.deltaTime;  //Countdown between two shots

        if(Input.GetKeyDown(KeyCode.Space) && CanShoot())
            Shoot();
    }

    private void Shoot()
    {
        addParticle();
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        countdownActual = 0f;
    }

    private bool CanShoot() 
    {
        return countdownActual >= countdownBetweenShoot;     //Countdown between two shots
    }

    void addParticle() {
        GameObject particle = (GameObject) Instantiate(particleBeforeShootPrefab, firePoint.position, firePoint.rotation);
        Destroy(particle,0.5f); 
    }
}
