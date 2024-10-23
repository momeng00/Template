using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImsiCard : MonoBehaviour, IDragHandler , IEndDragHandler, IBeginDragHandler
{
    public Hand hand;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 originalPosition;
    public RectTransform dropArea;
    public Cost cardCost;

    public virtual void Start()
    {
        hand = GameObject.FindGameObjectWithTag("DeckMaker").GetComponent<Hand>();
        dropArea = GameObject.FindGameObjectWithTag("Enemy").GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;
    }
    public virtual void Use()
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        // ���콺�� ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 worldPoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out worldPoint
        );

        // ���� ��ǥ�� UI ����� ���� ��ǥ�� ��ȯ
        rectTransform.position = worldPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RectTransform dropArea = GetValidDropArea();
        if (dropArea != null)
        {
            rectTransform.position = originalPosition;
            Use();
        }
        else
        {
            // ��� ������ ��ȿ���� ������ ���� ��ġ�� ����
            rectTransform.position = originalPosition;
        }
    }
    private RectTransform GetValidDropArea()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(dropArea, Input.mousePosition, canvas.worldCamera))
        {
            return dropArea;
        }
        return null;
    }

    private void Update()
    {
        
    }
    
}