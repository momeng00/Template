using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossMob : Stat
{
    public string _name;
    public GameObject hp_prefab;
    [SerializeField]public List<int[]> atk;
    [SerializeField]public RectTransform Hp_panel;
    [SerializeField]public RectTransform ATK_panel;
    GameObject[] hpList;
    public int ATK_stack;
    // Start is called before the first frame update
    void Start()
    {
        hpList=new GameObject[_hp.Length];
        SignHP(_hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpdateHP(6);
        }
    }
    public void SignHP(int[] hp)
    {
        for(int i=0; i<hp.Length;i++)
        {
            hpList[i] = Instantiate(hp_prefab);
            hpList[i].transform.SetParent(Hp_panel);
            if (hpList[i].GetComponent<ICanDice>() is ICanDice temp)
            {
                temp.textMeshPro.text = hp[i].ToString();
                if (i >= hp.Length-1)
                {

                }
                else
                {
                    GameObject plus = new GameObject();
                    plus.transform.SetParent(Hp_panel);
                    plus.AddComponent<RectTransform>();
                    plus.AddComponent<TextMeshProUGUI>();
                    plus.GetComponent<TextMeshProUGUI>().text = "+";
                    plus.GetComponent<TextMeshProUGUI>().fontSize = 96;
                    plus.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                    plus.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
                    plus.GetComponent<TextMeshProUGUI>().color = Color.black;
                }
            }
        }
    }
    public void UpdateHP(int dmg)
    {
        hp = dmg;
        
        for (int i = 0; i < _hp.Length; i++)
        {
            if (hpList[i].GetComponent<ICanDice>() is ICanDice temp)
            {
                temp.textMeshPro.text = _hp[i].ToString();
            }
        }
    }
    public void SignATK(List<int[]> atk)
    {

    }
}
