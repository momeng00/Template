using TMPro;
using UnityEngine;

public abstract class ICanDice : MonoBehaviour
{
    public bool _isDice;
    public TMP_Text textMeshPro;
    public bool isDice
    {
        get { return _isDice; }
        set
        {
            _isDice = value;
            if (_isDice)
            {
                Red();
            }
            else
            {
                Normal();
            }
        }
    }
    public virtual void Start()
    {
        isDice = false;
    }
    public void Red()
    {
        textMeshPro.color = Color.red;
    }
    public void Normal()
    {
        textMeshPro.color = Color.black;
    }

}