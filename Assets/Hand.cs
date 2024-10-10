using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField]DeckMaker deckMaker;
    [SerializeField]Button endTrunBTN;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EndTurn();
        }
    }
    public void EndTurn()
    {
        ImsiCard temp = deckMaker.DrawCard();
        if (temp == null)
            return;
        ImsiCard card =Instantiate(temp);
        card.transform.SetParent(transform);
    }
}
