using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerMovementController : NetworkBehaviour
{
    public float speed = 5f;
    public GameObject PlayerModel;

    private void Start()
    {
        PlayerModel.SetActive(false);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            if(PlayerModel.activeSelf == false)
            {

                SetPosition();
                PlayerModel.SetActive(true);

            }

            if(hasAuthority)
            {
                Movement();
            }
        }

    }

    public void SetPosition()
    {
        transform.position = new Vector3(Random.Range(1, 1), 0.8f, Random.Range(1, 1));
    }

    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        transform.position = newPosition;
    }
}

