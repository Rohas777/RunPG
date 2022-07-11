using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public bool isAttackClicked;
    public Image img;
    public Sprite sprite;
    public Sprite spritePressed;
    public Sprite spriteDisactive;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void TaskOnClick()
    {
        isAttackClicked = true;
        img.sprite = spritePressed;
    }
    public void TaskOnUp()
    {
        isAttackClicked = false;
        img.sprite = sprite;
    }
}
