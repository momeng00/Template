using UnityEngine;

public class CharacterController : MonoMovable
{
    public bool boost;
    private void Start()
    {
        speed = 1.2f;
    }
    public virtual void Update()
    {
        base.Update();
        direction = Input.GetAxis("Horizontal");
        Move();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2.0f;
        }
    }

}