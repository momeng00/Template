using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public MaxHp MaxHp;
    public CurHp CurHp;
    private int _ActPoint;
    public int ActPoint
    {
        get
        {
            return _ActPoint;
        }
        set
        {
            _ActPoint = value;
            UpdateActPoint();
        }
    }
    public GameObject[] actPoint;
    public bool UsePoint(int cost)
    {
        if(ActPoint - cost >= 0)
        {
            ActPoint = ActPoint - cost;
            return true;
        }
        return false;
    }
    public void UpdateActPoint()
    {
        for(int i = 0; i < ActPoint; i++)
        {
            actPoint[i].SetActive(true);
        }
        for (int i = ActPoint; i < actPoint.Length; i++)
        {
            actPoint[i].SetActive(false);
        }
    }

    public void HealPlayer(int value)
    {
        CurHp.value = CurHp.value + value;
    }

    public void HitPlayer(int value)
    {
        CurHp.value = CurHp.value - value;
        if(CurHp.value <= 0)
        {
            Debug.Log("player die : Game Over");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ActPoint = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurHp.value <= 0)
        {
            Die();
        }
    }
    public void Die()
    {

    }
}
