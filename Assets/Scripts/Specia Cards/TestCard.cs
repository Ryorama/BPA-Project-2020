using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCard : CardBase
{

    public Image card_img;
    public Sprite card_sprite;

    void Awake()
    {
        this.special_card = true;
        this.has_action = true;
        this.card_sprite_ui = card_img;
        this.card_sprite_table = card_sprite;
    }

    public override void Action()
    {
        Debug.Log("Works!");
    }
}
