using UnityEngine;
using UnityEngine.EventSystems;

public class ImsiCard : MonoBehaviour, Card, IDragHandler , IEndDragHandler, IBeginDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 originalPosition;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;
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
        rectTransform.position = originalPosition;
    }


    private void Update()
    {
        
    }
}