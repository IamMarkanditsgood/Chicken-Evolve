using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BasicScreen
{
    public Button p;
    public Button s;

    public TMP_Text coins;
    public TMP_Text reward;
    public TMP_Text timeToHome;
    private TextManager textManager = new TextManager();

    void Start()
    {
        p.onClick.AddListener(Profile);
        s.onClick.AddListener(Shop);

        GameEvents.OnNewCoins += UpdateCoins;
        GameEvents.OnNewReward += UpdateReward;
        GameEvents.OnNewTime += UdpateTimer;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        p.onClick.RemoveListener(Profile);
        s.onClick.RemoveListener(Shop);
        GameEvents.OnNewCoins -= UpdateCoins;
        GameEvents.OnNewReward -= UpdateReward;
        GameEvents.OnNewTime -= UdpateTimer;

    }

    public override void SetScreen()
    {
        textManager.SetText(PlayerPrefs.GetInt("Coins"), coins, true);
        textManager.SetText(PlayerPrefs.GetInt("Reward"), reward, true);
        textManager.SetText("10", timeToHome);
    }

    public void UpdateCoins(int Coins)
    {
        textManager.SetText(Coins, coins, true);
    }
    public void UpdateReward(int newReward)
    {
        textManager.SetText(newReward, reward, true);
    }
    public void UdpateTimer(int time)
    {
        textManager.SetText(time, timeToHome);
    }

    public override void ResetScreen()
    {
    }

    private void Profile()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Profile);
    }

    private void Shop()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Shop);
    }
}
