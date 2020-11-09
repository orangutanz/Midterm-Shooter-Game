using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerObj;
    private FPSController player;
    public Text text_Gold;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIUpdate()
    {
        text_Gold.text = "Gold:" + player.gold.ToString();
    }
}
