using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidBody;
    public Text collectedText;
    public static int collectedAmount = 0;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        int shootHor = (int)Input.GetAxisRaw("ShootHorizontal");
        int shootVert = (int)Input.GetAxisRaw("ShootVertical");
        if((shootHor!=0||shootVert!=0)&&Time.time>lastFire+fireDelay)
        {
            Shoot(shootHor, shootVert);
            lastFire = Time.time;
        }

        rigidBody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        collectedText.text = "Items Collected: " + collectedAmount;
    }

    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(x * bulletSpeed, y * bulletSpeed, 0);
    }
}
