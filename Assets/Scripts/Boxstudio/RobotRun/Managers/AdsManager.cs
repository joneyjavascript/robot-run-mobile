
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    [SerializeField] string _androidGameId;
    [SerializeField] bool _testMode = true;

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
        Debug.Log("Advertisement.Show");
        Advertisement.Show();
      } else {
        Debug.Log("Advertisement Not Ready");
      }
    }
 
    public void InitializeAds()
    {
      Debug.Log("Advertisement.Initialize - " + _androidGameId + (_testMode ? "(TestMode)" : ""));
      Advertisement.Initialize(_androidGameId, _testMode);
    }
}