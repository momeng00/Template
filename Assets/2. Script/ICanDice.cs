using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ICanDice : MonoBehaviour, IPointerDownHandler
{
    public bool _isDice;
    public int _value;
    public TMP_Text textMeshPro;
    public GameObject parent;
    public int diceValue;

    public int value
    {
        get { return _value; }
        set
        {
            if(_value != value)
            {
                _value = value;
                textMeshPro.text = _value.ToString();
            }
            return;
        }
    }
    public void Initialize(GameObject parent)
    {
        this.parent = parent;
    }
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

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (_isDice)
        {
            value = diceValue;
        }
    }
}