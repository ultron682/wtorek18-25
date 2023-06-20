using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lock : MonoBehaviour
{
    public PortalDoor[] doors;
    public KeyColor myColor;
    bool iCanOpen = false;
    bool locked = false;
    Animator key;


    private void Start()
    {
        key = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You Can Use Lock");
            if (locked == false)
                GameManager.Instance.Text_PressE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You Can not Use Lock");
            GameManager.Instance.Text_PressE.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("Open", CheckTheKey());
            GameManager.Instance.Text_PressE.SetActive(false);
        }
    }
    public void UseKey()
    {
        foreach (PortalDoor door in doors)
        {
            door.OpenClose();
        }
    }

    public bool CheckTheKey()
    {
        if (GameManager.Instance.redKeys > 0 && myColor == KeyColor.Red)
        {
            GameManager.Instance.redKeys--;
            locked = true;
            GameManager.Instance.Text_redKey.text = GameManager.Instance.redKeys.ToString();
            return true;
        }
        else if (GameManager.Instance.greenKeys > 0 && myColor == KeyColor.Green)
        {
            GameManager.Instance.greenKeys--;
            locked = true;
            GameManager.Instance.Text_greenKey.text = GameManager.Instance.greenKeys.ToString();
            return true;
        }
        else if (GameManager.Instance.goldKeys > 0 && myColor == KeyColor.Gold)
        {
            GameManager.Instance.goldKeys--;
            locked = true;
            GameManager.Instance.Text_goldKey.text = GameManager.Instance.goldKeys.ToString();
            return true;
        }
        else
        {
            Debug.Log("Nie masz klucza!");
            return false;
        }
    }
}
