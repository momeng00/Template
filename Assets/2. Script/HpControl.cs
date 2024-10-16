using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HpControl : ICanDice,IPointerDownHandler
{
    public int curHP;
    public override void Start()
    {
        base.Start();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isDice = !isDice;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}