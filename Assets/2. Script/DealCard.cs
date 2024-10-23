using UnityEngine;

public class DealCard : ImsiCard
{
    public BossMob boss;
    public Stat Dmg;
    public override void Start()
    {
        base.Start();
        cardCost.value = 2;
        Dmg.value = 2;
    }
    public override void Use()
    {
        base.Use();
        if (hand.GetComponent<Player>().UsePoint(cardCost.value))
        {
            hand.hand_card.Remove(gameObject.GetComponent<ImsiCard>());
            hand.ReturnCard(gameObject.GetComponent<ImsiCard>());
            boss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossMob>();
            boss.UpdateHP(Dmg.value);
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}