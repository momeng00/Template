using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoMovable
{
    public bool boost;
    public GameObject HideObject;
    private void Start()
    {
        HideObject = null;
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
        if(HideObject != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                HideObject.gameObject.transform.position += new Vector3(direction*speed* Time.deltaTime,0.0f,0.0f);
            }
        }
    }
    public void CanHide()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (HideObject == null && collision.gameObject.layer == LayerMask.NameToLayer("Hide"))
        {
            HideObject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == HideObject)
        {
            HideObject = null;
        }
    }
}