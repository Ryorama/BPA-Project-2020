using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //The base variables for the game
    public int player_one_cards = 0;
    public int player_two_cards = 0;
    public int round = 0;
    public int players_turn = 0;

    public GameManager instance;

    public GameObject player_one_hand_obj;

    public static bool minigame_active = false;

    public List<CardBase> cards_list = new List<CardBase>();


    //Card Image and Sprite registry
    public Image one_card_img;
    public Sprite one_card_sprite;

    public Image zero_card_img;
    public Sprite zero_card_sprite;

    //List of the player's hands
    public List<CardBase> player_one_hand = new List<CardBase>();
    public List<CardBase> player_two_hand = new List<CardBase>();

    void Start()
    {
        player_one_cards = 10;
        player_two_cards = 10;

        instance = this;

        Setup();
    }

    void Update()
    {
        
    }

    public void Setup()
    {
        round = 1;
        players_turn = Random.Range(1, 3);

        cards_list.Clear();
        cards_list.Add(new CardBase(false, false, one_card_img, one_card_sprite));
        cards_list.Add(new CardBase(false, false, zero_card_img, zero_card_sprite));

        for (int i = 0; i <= cards_list.Count; i++)
        {
            CardBase.id += 1;
        }

        GiveStartCards();
    }

    public void GiveStartCards()
    {
        player_one_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);
        player_two_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);
        
        player_one_hand.Add(cards_list[Random.Range(0, CardBase.id -1)]);
        player_two_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);

        player_one_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);
        player_two_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);

        player_one_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);
        player_two_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);

        player_one_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);
        player_two_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);

        player_one_hand_obj.transform.Find("Card1").GetComponent<Image>().sprite = player_one_hand[0].card_sprite_table;
        player_one_hand_obj.transform.Find("Card2").GetComponent<Image>().sprite = player_one_hand[1].card_sprite_table;
        player_one_hand_obj.transform.Find("Card3").GetComponent<Image>().sprite = player_one_hand[2].card_sprite_table;
        player_one_hand_obj.transform.Find("Card4").GetComponent<Image>().sprite = player_one_hand[3].card_sprite_table;
        player_one_hand_obj.transform.Find("Card5").GetComponent<Image>().sprite = player_one_hand[4].card_sprite_table;
    }
}

