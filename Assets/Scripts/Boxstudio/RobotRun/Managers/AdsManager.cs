
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    int countDownAds = 0;

    void Awake(){
      if(instance == null){
        instance = this;
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
        Advertisement.Show("Interstitial_Android");
      }
    }
}