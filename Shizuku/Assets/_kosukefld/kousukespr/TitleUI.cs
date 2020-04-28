﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    

    public PushAUI aui;

    public Image Title;
    public GameObject canvas;
    public GameObject starttext;
    public GameObject button;
    public GameObject button2;

    private RectTransform data;

    Color color;
    Color color2;

    int CL_MAX = 255;
    int sizemax = 100;
    int nextselect = 0;
    int posxmin = -573;
    int posymin = 289;
    float poscount = 0;
    float sizenow = 0;
    float CL_now = 0;
    float sizecount = 0;
    float colorcount = 0;
    float nextsizex = 0;
    float nextsizey = 62;

    bool nextST = false;
    bool action = false;
    bool textcheck = false;
    bool buttoncheck = false;
    bool stratcheck = true;

    public bool Titletest()
    {
        return action;
    }

    public bool BuuttonCK()
    {
        return buttoncheck;
    }

    public bool stratCK()
    {
        return stratcheck;
    }

    public int nextCK()
    {
        return nextselect;
    }

    void Start()
    {
        //text.SetActive(false);
        data = GetComponent<RectTransform>();
        //color.a = 0;
        //RectTransform rectTransform = GetComponent<RectTransform>();
        Title.color = new Color32(255, 255, 255, 0);
    }

    
    
    void Update()
    {
        //position data.anchoredPosition
        if (Input.GetKeyDown(KeyCode.JoystickButton2) == true)
        {
            Debug.Log(data.anchoredPosition);
        }

        data.sizeDelta = new Vector2(sizenow, sizenow);
        Title.color = new Color32(255,255,255,(byte)CL_now);
        data.anchoredPosition = new Vector2(nextsizex,nextsizey);
        if (nextST == false)
        {
            if (sizecount < 1)
            {
                sizenow = Mathf.Lerp(0, sizemax, sizecount);
                sizecount += 0.01F;


            }
            else if (!textcheck)
            {
                action = true;
                textcheck = true;
                starttext.SetActive(true);
            }
            if (sizecount > 0.4f && colorcount < 1)
            {
                CL_now = Mathf.Lerp(0, CL_MAX, colorcount);
                colorcount += 0.01F;
            }
        }
       
        if(nextST==true)
        {
            if (poscount < 1)
            {
                nextsizex = Mathf.Lerp(0, posxmin, poscount);
                nextsizey = Mathf.Lerp(62, posymin, poscount);
                poscount += 0.05f;
            }
            if (sizecount > 0.7f)
            {
                sizenow = Mathf.Lerp(0, sizemax, sizecount);
                sizecount -= 0.015F;


            }

        }
      

        if (Input.GetKeyDown(KeyCode.JoystickButton0) == true&&Titletest()==true&&buttoncheck==false)
        {
            stratcheck = false;
            nextST = true;
        }

        if(aui.destroyCK()==true)
        {
            if (!buttoncheck)
            {
                buttoncheck = true;
                button.SetActive(true);
                button2.SetActive(true);
            }
        }
        if (buttoncheck == true&& Input.GetAxis("Axis 7") > 0f)
        {
            nextselect = 1;
            
        }
        if(buttoncheck == true && Input.GetAxis("Axis 7") < 0f)
        {
            nextselect = 2;
            
        }

    }
    //if (Input.GetKeyDown(KeyCode.JoystickButton2) == true)
    //    {
    //        Debug.Log();
    //    }
}
