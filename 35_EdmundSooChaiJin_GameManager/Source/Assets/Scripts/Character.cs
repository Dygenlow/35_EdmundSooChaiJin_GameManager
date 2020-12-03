using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float speed;

    public int energyCount;

    public GameObject energyCounter;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ForwardKey();
        BackKey();
        LeftKey();
        RightKey();

        energyCounter.GetComponent<Text>().text = "Energy: " + energyCount;

        if(GameManager.instance.levelTime <= 0)
        {
            speed = 0;
        }

        if(energyCount < 0 || GameManager.instance.levelTime < 0)
        {
            GameManager.instance.LoseScene();
        }

        if(energyCount > 50)
        {
            GameManager.instance.WinScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AddEnergy"))
        {
            energyCount = energyCount + 5;

            GameManager.instance.AddTime();

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("MinusEnergy"))
        {
            energyCount = energyCount - 25;

            Destroy(other.gameObject);
        }
    }
    private void ForwardKey()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);

            playerAnim.SetBool("isMoving", true);
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void BackKey()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);

            playerAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void LeftKey()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);

            playerAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void RightKey()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);

            playerAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerAnim.SetBool("isMoving", false);
        }
    }
}
