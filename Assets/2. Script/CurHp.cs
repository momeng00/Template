using UnityEngine.EventSystems;

public class CurHp : ICanDice 
{
    public MaxHp maxHp;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (diceValue > maxHp.value)
        {
            value = maxHp.value;
        }
    }
    private void Update()
    {
        if (value >= maxHp.value)
        {
            value = maxHp.value;
        }
    }

}