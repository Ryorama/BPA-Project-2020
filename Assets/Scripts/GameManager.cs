using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //The base variables for the game
    public int player_one_cards = 0;
    public int player_two_cards = 0;
    public int round = 0;
    public int players_turn = 0;

    public GameManager instance;

    public GameObject[] cards;

    public GameObject player_one_hand_obj;

    public static bool minigame_active = false;

    public List<CardBase> cards_list = new List<CardBase>();

    public bool is_game_setup = false;

    public bool turn_in_progress = false;
 

    //Card Image and Sprite registry
    public Image red_one_card_img;
    public Sprite red_one_card_sprite;

    public Image red_zero_card_img;
    public Sprite red_zero_card_sprite;

    public Image green_one_card_img;
    public Sprite green_one_card_sprite;

    public Image green_zero_card_img;
    public Sprite green_zero_card_sprite;

    public Image blue_one_card_img;
    public Sprite blue_one_card_sprite;

    public Image blue_zero_card_img;
    public Sprite blue_zero_card_sprite;

    public Image wild_plus_four_card_img;
    public Sprite wild_plus_four_card_sprite;

    //List of the player's hands
    public List<CardBase> player_one_hand = new List<CardBase>();
    public List<CardBase> player_two_hand = new List<CardBase>();


    //Extra Player Card Gameobjects
    public GameObject card6;

    void Start()
    {
        player_one_cards = 10;
        player_two_cards = 10;

        instance = this;

        Setup();
    }

    void Update()
    {
        bool cardCheckInProgress = false;

        if (is_game_setup && !turn_in_progress)
        {
            if (players_turn == 1)
            {
                RunPlayerOneTurn();
            }

            if (players_turn == 2)
            {
                RunPlayerTwoTurn();
            }
        }

        if (!cardCheckInProgress)
        {
            cardCheckInProgress = true;

            for (int i = 0; i < cards.Length; i++)
            {
                if (!player_one_hand[i].isWildFour)
                {
                    if (cards[i].GetComponent<CardBase>() == null)
                    {
                        cards[i].AddComponent<CardBase>();
                    }
                    cards[i].GetComponent<Button>().onClick.AddListener(cards[i].GetComponent<CardBase>().UseAction);
                }
                else
                {
                    if (cards[i].GetComponent<PlusFourWildCard>() == null)
                    {
                        cards[i].AddComponent<PlusFourWildCard>();
                    }
                    cards[i].GetComponent<Button>().onClick.AddListener(cards[i].GetComponent<PlusFourWildCard>().Action);
                }
            }

            cardCheckInProgress = false;
        }
    }

    public void Setup()
    {
        round = 1;
        players_turn = Random.Range(1, 3);

        cards_list.Clear();
        cards_list.Add(new CardBase(false, false, red_one_card_img, red_one_card_sprite));
        cards_list.Add(new CardBase(false, false, red_zero_card_img, red_zero_card_sprite));
        cards_list.Add(new CardBase(false, false, green_one_card_img, green_one_card_sprite));
        cards_list.Add(new CardBase(false, false, green_zero_card_img, green_zero_card_sprite));
        cards_list.Add(new CardBase(false, false, blue_one_card_img, blue_one_card_sprite));
        cards_list.Add(new CardBase(false, false, blue_zero_card_img, blue_zero_card_sprite));
        cards_list.Add(new PlusFourWildCard(wild_plus_four_card_img, wild_plus_four_card_sprite));

        for (int i = 0; i <= cards_list.Count; i++)
        {
            CardBase.id += 1;
        }

        GiveStartCards();

        is_game_setup = true;
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

    public void RunPlayerOneTurn()
    {
        turn_in_progress = true;

        player_one_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);

        if (player_one_hand.Count == 5)
        {
            card6.SetActive(true);
            player_one_hand_obj.transform.Find("Card6").GetComponent<Image>().sprite = player_one_hand[5].card_sprite_table;
        }

        players_turn = 2;

        turn_in_progress = false;
    }

    public void RunPlayerTwoTurn()
    {
        turn_in_progress = true;

        player_two_hand.Add(cards_list[Random.Range(0, CardBase.id - 1)]);
       
        players_turn = 1;

        turn_in_progress = false;
    }
}

