using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Stat : MonoBehaviour
{
    public int[] _hp;
    public TMP_Text hpText;
    public TMP_Text atkText;
    public int hp
    {
        get { return hp;} 
        set {
            int temp = value;
            for(int i = _hp.Length-1; i >= 0; i--)
            {
                Debug.Log(i);
                if (_hp[i] - temp < 0)
                {
                    temp = temp - _hp[i];
                    _hp[i] = 0;
                }
                else
                {
                    _hp[i] = _hp[i] - temp;
                    break;
                }
            }
            if(_hp.Sum() <=0)
            {
                Debug.Log("End");
            }
        }
    }
    public void ClearBoss()
    {
        //hpText.text = string.Join(" + ", _hp);
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearBoss();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
