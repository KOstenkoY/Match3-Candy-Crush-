using System;
using AppsFlyerSDK;
using UnityEngine;
using UnityEngine.UI;

public class ConverionDataSuccess : MonoBehaviour
{
    [SerializeField] private AppsFlyerObjectScript _appsFlyerObject;
    [SerializeField] private Text _conversionDataSeccessText;
    string conversionData;

    private void Start()
    {
        _appsFlyerObject.onConversionDataSuccess(conversionData);
        _conversionDataSeccessText.text = AppsFlyer.getAppsFlyerId();
        
    }
}
