using UnityEngine;

public class DealCard : ImsiCard
{
    public BossMob boss;
    public int Dmg;
    public override void Use()
    {
        base.Use();
        boss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossMob>();
        boss.UpdateHP(Dmg);
    }
}