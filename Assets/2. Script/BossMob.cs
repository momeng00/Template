using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BossMob : MonoBehaviour
{
    public string _name;
    public GameObject hp_prefab;
    public GameObject atk_prefab;
    [SerializeField]public RectTransform Hp_panel;
    [SerializeField]public RectTransform ATK_panel;
    [SerializeField]private Stat_Hp[] _hp;
    private List<int[]> _atkList;
    private Stat_ATK[] _atk; //실제 사용될 list

    //temp
    private int[] temp_hp;
    private int[] temp_atk;
    private int[] temp_atk1;
    private int[] temp_atk2;
    private List<int[]> temp_atklist;
    //

    GameObject[] atkList;
    GameObject[] hpList;
    public int ATK_stack;
    // Start is called before the first frame update
    public void Start()
    {
        ATK_stack = 0;

        temp_hp = new int[3];
        temp_hp[0] = 60;
        temp_hp[1] = 60;
        temp_hp[2] = 60;

        temp_atk1 = new int[1];
        temp_atk1[0] = 2;
        temp_atk2 = new int[3];
        temp_atk2[0] = 1;
        temp_atk2[1] = 1;
        temp_atk2[2] = 1;
        temp_atklist = new List<int[]>();
        temp_atklist.Add(temp_atk1);
        temp_atklist.Add(temp_atk2);
        _atkList = new List<int[]>(temp_atklist);
        temp_atk = _atkList[ATK_stack];
        _atk = new Stat_ATK[temp_atk.Length];
        SignATK(_atk);

        _hp = new Stat_Hp[temp_hp.Length];
        hpList = new GameObject[_hp.Length];
        SignHP(_hp);
        for (int i = 0; i < _hp.Length; i++)
        {
            _hp[i].value = temp_hp[i];
            _hp[i].Initialize(gameObject);
        }
        Debug.Log(_atk.Length);
        for (int i = 0; i < _atk.Length; i++)
        {
            _atk[i].value = temp_atk[i];
            _atk[i].Initialize(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpdateHP(6);
        }
    }
    public int CheckDMG()
    {
        int result = 0;
        foreach (Stat_ATK value in _atk)
        {
            result += value.value;
        }
        return result;
    }
    public void GetBossData(Stat_Hp[] hp, List<Stat_ATK[]> atk)
    {

    }
    public void SignHP(ICanDice[] hp)
    {
        for(int i=0; i<hp.Length;i++)
        {
            hpList[i] = Instantiate(hp_prefab);
            hpList[i].transform.SetParent(Hp_panel);
            if (hpList[i].GetComponent<ICanDice>() is ICanDice temp)
            {
                _hp[i] = (Stat_Hp)temp;
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
        HpChange(dmg);
    }
    public void SignATK(ICanDice[] atk)
    {
        foreach (Transform child in ATK_panel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        atkList = new GameObject[_atk.Length];
        //_atk = new Stat_ATK[temp_atklist.Count];
        for (int i = 0; i < atk.Length; i++)
        {
            atkList[i] = Instantiate(atk_prefab);
            atkList[i].transform.SetParent(ATK_panel);
            if (atkList[i].GetComponent<ICanDice>() is ICanDice temp)
            {
                _atk[i] = (Stat_ATK)temp;
                if (i >= atk.Length - 1)
                {

                }
                else
                {
                    GameObject plus = new GameObject();
                    plus.transform.SetParent(ATK_panel);
                    plus.AddComponent<RectTransform>();
                    plus.AddComponent<TextMeshProUGUI>();
                    plus.GetComponent<TextMeshProUGUI>().text = "+";
                    plus.GetComponent<TextMeshProUGUI>().fontSize = 48;
                    plus.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
                    plus.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
                    plus.GetComponent<TextMeshProUGUI>().color = Color.black;
                }
            }
        }
    }

    public void HpChange(int value)
    {
        int temp = value;
        int Sum = 0;
        for (int i = _hp.Length - 1; i >= 0; i--)
        {
            if (_hp[i].value - temp < 0)
            {
                temp = temp - _hp[i].value;
                _hp[i].value = 0;
            }
            else
            {
                _hp[i].value = _hp[i].value - temp;
                break;
            }
        }
        foreach (var v in _hp)
        {
            Sum += v.value;
        }
        if (Sum <= 0)
        {
            Debug.Log("End");
        }
    }
}
