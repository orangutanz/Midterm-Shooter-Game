using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager mInstance;
    public GameObject playerObj;
    private FPSController player;
    public Text text_Gold;
    //public Text text_Ammo;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();
    }

    GameManager Get()
    {
        if(mInstance == null)
        {
            mInstance = new GameManager();
        }
        return mInstance;
    }
    

    public void UIUpdate()
    {
        text_Gold.text = "Gold: " + player.gold.ToString();
        //text_Ammo.text = "Ammo: " + player.currentWeapon.GetComponent<Weapon>().bulletsPerMagazine.ToString();
    }
}
