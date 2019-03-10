using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorldScroll : MonoBehaviour, IBeginDragHandler,IEndDragHandler
{
    private ScrollRect scrollRect;
    public GameObject[] WorldStart = new GameObject[4];
    public GameObject Start_off = null;
    private int[] Worldkey = new int[4] {1,1,0,0};

    private float[] pageArray = new float[] { 0, 0.33333f, 0.66666f, 1 };

    // Use this for initialization
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = scrollRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Math.Abs(pageArray[index] - posX);

        for(int i = 0; i < pageArray.Length; i++)
        {
            float offsetTemp = Math.Abs(pageArray[i] - posX);
            if (offsetTemp < offset)
            {
                index = i;
                offset = offsetTemp;
            }

            WorldStart[i].SetActive(false);
            Start_off.SetActive(false);
        }

        scrollRect.horizontalNormalizedPosition = pageArray[index];

        if (Worldkey[index] == 1)
        {
            WorldStart[index].SetActive(true);
        }
        else
        {
            WorldStart[index].SetActive(false);
            Start_off.SetActive(true);
        }
    }

    
}
