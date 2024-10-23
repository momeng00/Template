using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceCard : ImsiCard
{
    public ICanDice[] canDices;
    public bool isDirty;
    public override void Start()
    {
        base.Start();
        isDirty = false;
        cardCost.value = 2;
    }
    private void Update()
    {
        if (!isDirty)
            return;
        if (Input.GetMouseButton(0))
        {
            foreach (var canDice in canDices)
            {
                canDice.isDice = false;
                isDirty = false;
            }
            gameObject.SetActive(false);
        } 
    }
    public override void Use()
    {
        base.Use();
        if (hand.GetComponent<Player>().UsePoint(cardCost.value))
        {
            hand.hand_card.Remove(gameObject.GetComponent<ImsiCard>());
            hand.ReturnCard(gameObject.GetComponent<ImsiCard>());
            canDices = FindObjectsOfType<ICanDice>();
            int temp = Random.Range(1, 7);
            foreach (var canDice in canDices)
            {
                canDice.isDice = true;
                canDice.diceValue = temp;
            }
            isDirty = true;
        }
        else
        {
            return;
        }
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    if (RectTransformUtility.RectangleContainsScreenPoint(cost, eventData.position))
    //    {
    //        HandleClick("cost");
    //    }
    //    else if (RectTransformUtility.RectangleContainsScreenPoint(value, eventData.position))
    //    {
    //        HandleClick("value");
    //    }
    //}

    //private void HandleClick(string v)
    //{
    //    if (!_isDice)
    //        return;
    //    switch (v)
    //    {
    //        case "cost":
    //            Debug.Log("rect1�� Ŭ���Ǿ����ϴ�.");
    //            // rect1 Ŭ�� �� ó���� ����
    //            break;
    //        case "value":
    //            Debug.Log("rect2�� Ŭ���Ǿ����ϴ�.");
    //            // rect2 Ŭ�� �� ó���� ����
    //            break;
    //    }
    //}
}