using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public GameObject lazerPrefab;
    private float fireRate=0.2f;
    private float nextFire;
    [SerializeField ]
    private GameObject playerExplosionPrefab;

    private int playerLives = 5;

    [SerializeField]
    private int speed = 12;

    [SerializeField]
    private AudioSource lazerShot;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        lazerShot = GetComponent<AudioSource>();
    }


    void Update()
    {
        SpaceMovement();

       if (Input.GetMouseButton(0))
        {
            if(Time.time>nextFire)
            {
                lazerShot.Play();
                Instantiate(lazerPrefab, transform.position + new Vector3(0, -2f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
                 
        }
    }
    public void LifeSubstraction()
    {
        playerLives--;

        if (playerLives<1)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }


    }

        




    private void SpaceMovement()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertInput);

        if (transform.position.y > 15)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -15.07f)
        {
            transform.position = new Vector3(transform.position.x, -4.07f, 0);
        }
        if (transform.position.x > 31.5f)
        {
            transform.position = new Vector3(31f, transform.position.y, 0);
        }
        else if (transform.position.x < -31.5f)
        {
            transform.position = new Vector3(-31f, transform.position.y, 0);
        }
    }
}
