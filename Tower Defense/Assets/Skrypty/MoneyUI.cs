using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{

    public Text moneyText;

    void Update()
    {
        moneyText.text = "$" + PlayerStat.Money.ToString();
    }
}
