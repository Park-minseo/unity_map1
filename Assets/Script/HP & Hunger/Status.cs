using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Status : MonoBehaviour
{

    public int player_hp = 40;
    public int player_hunger = 10;

    public Sprite hp_full, hp_threequarter, hp_half, hp_quarter, hp_empty;
    public Sprite hunger_full, hunger_empty;

    public GameObject Hp, Hunger;


    void Update()
    {
        ChangeHP();
        ChangeHunger();
    }
    public void ChangeHP()
    {
        for (int i = 0; i < 10; i++)
        {

            Transform hp_child = Hp.transform.GetChild(i);
            Image hp_img = hp_child.GetComponent<Image>();

            int isempty = i * 4;

            if (player_hp <= isempty) hp_img.sprite = hp_empty;
            else if (player_hp >= isempty + 4) hp_img.sprite = hp_full;
            else if (player_hp == isempty + 1) hp_img.sprite = hp_quarter;
            else if (player_hp == isempty + 2) hp_img.sprite = hp_half;
            else hp_img.sprite = hp_threequarter;

        }
    }
    public void ChangeHunger()
    {
        for (int i = 0; i < 10; i++)
        {

            Transform hunger_child = Hunger.transform.GetChild(i);
            Image hunger_img = hunger_child.GetComponent<Image>();

       
            if (player_hunger <= i) hunger_img.sprite = hunger_empty;
            else  hunger_img.sprite = hunger_full;

        }
    }
}
