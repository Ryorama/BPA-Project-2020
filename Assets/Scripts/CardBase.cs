using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBase : MonoBehaviour
{

    public static int id;
    public bool special_card;
    public bool has_action;

    public Image card_sprite_ui;
    public Sprite card_sprite_table;

    public CardBase() {}

    public CardBase(bool sc, bool ha, Image img, Sprite sp)
    {
        special_card = sc;
        has_action = ha;
        card_sprite_ui = img;
        card_sprite_table = sp;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public virtual void Action()
    {

    }
}
