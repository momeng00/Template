using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : ImsiCard
{
    public Player player;
    public Stat healAmount;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        healAmount.value = 2;
        cardCost.value = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Use()
    {
        base.Use();
        if (hand.GetComponent<Player>().UsePoint(cardCost.value))
        {
            hand.hand_card.Remove(gameObject.GetComponent<ImsiCard>());
            hand.ReturnCard(gameObject.GetComponent<ImsiCard>());
            hand.GetComponent<Player>().HealPlayer(healAmount.value);
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
