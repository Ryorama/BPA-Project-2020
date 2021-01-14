using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusFourWildCard : CardBase
{

    public PlusFourWildCard(Image card_img, Sprite card_sprite)
    {
        this.card_sprite_ui = card_img;
        this.card_sprite_table = card_sprite;
        this.isWildFour = true;
    }

    void Awake()
    {
        this.special_card = true;
        this.has_action = true;
    }

    public override void OnUse()
    {
        this.Action();
    }

    public void Action()
    {
        Debug.Log("Wild and +4!");
    }
}
