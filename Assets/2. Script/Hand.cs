using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    private const int MAX = 5;
    public LinkedList<ImsiCard> hand_card;
    [SerializeField]DeckMaker deckMaker;
    [SerializeField]Button endTrunBTN;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        endTrunBTN.onClick.AddListener(EndTurn);
        hand_card = new LinkedList<ImsiCard>();
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
        for (int i=0; i<3; i++)
        {
            if (hand_card.Count >= MAX)
                return;
            ImsiCard temp = deckMaker.DrawCard();
            if (temp == null)
                return;
            ImsiCard card = Instantiate(temp);
            hand_card.AddLast(card);
            card.transform.SetParent(transform);
        }  
    }

    public void ReturnCard(string card)
    {
        deckMaker.ReturnCard(card);
    }
}
