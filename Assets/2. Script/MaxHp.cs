using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class MaxHp : ICanDice
{
    public CurHp curHp;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (curHp.value > value)
        {
            curHp.value = value;
        }
    }
}