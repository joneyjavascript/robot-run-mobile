
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    [SerializeField] string _androidGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    int countDownAds = 0;

    void Awake(){
      if(instance == null){
        instance = this;
        InitializeAds();
      }
    }

    public bool CountDownAds(){
      countDownAds++;
      if(countDownAds % 3 == 0){
        ShowAd();
        return true;
      }

      return false;
    }

    public void ShowAd()
    {
      if (Advertisement.IsReady())
      {
        Advertisement.Show();
      }
    }
 
    public void InitializeAds()
    {
      Advertisement.Initialize(_androidGameId, _testMode, this);
    }
}