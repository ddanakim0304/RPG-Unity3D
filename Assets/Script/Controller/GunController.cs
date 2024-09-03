using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletSpawnPoint;

    public float bulletSpeed = 1000;
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_input.shoot)
        {
            shoot();
            _input.shoot = false;
        }
    }

    void shoot()
    {
        Debug.Log("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
        bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.transform.forward * bulletSpeed);
        Destroy(bullet, 1.5f);
}
    }
