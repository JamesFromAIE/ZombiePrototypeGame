using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float gunFireRate = 1;
    private float gunFireRate_time;
    private Animator anim;
    GameObject bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnPoint = transform.GetChild(0).gameObject;

        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > gunFireRate_time)
        {
            gunFireRate_time = Time.time + gunFireRate;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

            anim.SetTrigger("Active");
        }
        else
        {
            anim.SetTrigger("InActive");
        }
    }
}
