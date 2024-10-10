using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMaker : MonoBehaviour
{
    [SerializeField]List<ImsiCard> deck; //��ü ���� ī��
    [SerializeField]List<ImsiCard> cards; //���� ī��

    private void Awake()
    {
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
