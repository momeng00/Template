using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoMovable : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _direction; //움직일 방향 왼쪽,오른쪽만 하기에 float 
    public float direction
    {
        get
        {
            return _direction;
        }
        set 
        {
            if(value < 0)
            {
                transform.localScale= new Vector3(1.0f, -1.0f, 1.0f);
            }
            else if(value > 0)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            _direction = value;
        }
    }
    private float _speed; //움직일 속도 speed
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public void Update()
    {
        move = new Vector2(direction * speed, 0.0f);
    }
    public void Move()
    {
        rb.position += move * Time.deltaTime;
    }
}
