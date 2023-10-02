using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    [SerializeField] public float BulletSpeed = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawnPoint.up * BulletSpeed;
        }
    }
}
