using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMaker : MonoBehaviour
{
    List<ImsiCard> deck; //전체 보유 카드
    List<ImsiCard> cards; //사용될 카드

    private void Awake()
    {
        deck = new List<ImsiCard>();
        cards = new List<ImsiCard>();
        deck.Add((Resources.Load<ImsiCard>("Heal")));
        deck.Add((Resources.Load<ImsiCard>("Heal")));
        deck.Add((Resources.Load<ImsiCard>("Deal")));
        deck.Add((Resources.Load<ImsiCard>("Deal")));
        deck.Add((Resources.Load<ImsiCard>("Dice")));
        deck.Add((Resources.Load<ImsiCard>("Dice")));
        GameStart();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public ImsiCard DrawCard()
    {
        if (cards.Count <= 0)
            return null;
        int temp = Random.Range(0, cards.Count);
        ImsiCard card;
        if (cards.Count >= 0)
        {
            card = cards[temp];
            cards.RemoveAt(temp);
            return card;
        }
        return null;
    }
    public void ReturnCard(string card)
    {
        Debug.Log(card);
        cards.Add((Resources.Load<ImsiCard>(card)));
    }
    public void GameStart()
    {
        cards.Clear();
        cards = new List<ImsiCard>(deck);
    }
    public void AddCard(ImsiCard card)
    {
        deck.Add(card);
    }

}
