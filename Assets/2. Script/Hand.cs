using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    private const int MAX = 5;
    public LinkedList<ImsiCard> hand_card;
    private Player player;
    BossMob boss;
    DeckMaker deckMaker;
    public Button endTrunBTN;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        deckMaker = GetComponent<DeckMaker>();
        player = GetComponent<Player>();
        endTrunBTN.onClick.AddListener(EndTurn);
        hand_card = new LinkedList<ImsiCard>();
        boss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossMob>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EndTurn()
    {
        player.ActPoint = 4;
        player.HitPlayer(boss.CheckDMG());
        for (int i=0; i<3; i++)
        {
            if (hand_card.Count >= MAX)
                return;
            ImsiCard card = deckMaker.DrawCard();
            if (card == null)
                return;
            card.gameObject.SetActive(true);
            card.transform.SetAsLastSibling();
            hand_card.AddLast(card);
        }
    }

    public void ReturnCard(ImsiCard card)
    {
        deckMaker.ReturnCard(card);
    }
}
