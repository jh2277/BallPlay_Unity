using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{

    public float jumpPower; //public «œ∏È inspector√¢ø° ∂‰
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;

    AudioSource audio;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump=true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            manager.GetItem(itemCount);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Finish")
        {
            if(manager.totalItemCount == itemCount)
            {
                if (manager.stage == 2)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage + 1);
            }
            else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
    }


}
