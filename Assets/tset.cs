using BestHTTP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tset : MonoBehaviour
{
    private Dictionary<string, DateTime> map = new Dictionary<string, DateTime>();

    private void Awake()
    {
        BestHTTP.HTTPManager.Setup();
    }
    public void SendRequest()
    {
        map.Clear();
        string url = "http://miragearcntest.lenovo.com/Mirage/app/getSplashScreenList";
        map.Add(url, DateTime.UtcNow);
        HTTPRequest request = new HTTPRequest(new Uri(url), HTTPMethods.Post, OnRequestFinished1);
        request.AddField("deviceType", "android");        request.Send();
        Debug.Log("============1");

        url = "http://miragearcntest.lenovo.com/Mirage/home/getAppRecommends";
        map.Add(url, DateTime.UtcNow);
        request = new HTTPRequest(new Uri(url), HTTPMethods.Post, OnRequestFinished2);
        request.AddField("deviceType", "android");        request.Send();
        Debug.Log("============2");

        url = "http://miragearcntest.lenovo.com/Mirage/app/getPackageVersion";
        map.Add(url, DateTime.UtcNow);
        request = new HTTPRequest(new Uri(url), HTTPMethods.Post, OnRequestFinished3);
        request.AddField("deviceType", "android");        request.AddField("versionCode", "102");        request.Send();
        Debug.Log("============3");
    }

    void OnRequestFinished1(HTTPRequest request, HTTPResponse response)
    {
        string url = request.Uri.ToString();
        DateTime countTime;
        map.TryGetValue(url, out countTime);
        Debug.Log(request.Uri.ToString() + ":" + response.DataAsText);
        TimeSpan t = DateTime.UtcNow - countTime;
        Debug.Log("comsumer  time ::" + t.Milliseconds);
    }    void OnRequestFinished2(HTTPRequest request, HTTPResponse response)
    {
        string url = request.Uri.ToString();
        DateTime countTime;
        map.TryGetValue(url, out countTime);
        Debug.Log(request.Uri.ToString() + ":" + response.DataAsText);
        TimeSpan t = DateTime.UtcNow - countTime;
        Debug.Log("comsumer  time ::" + t.Milliseconds);
    }    void OnRequestFinished3(HTTPRequest request, HTTPResponse response)
    {
        string url = request.Uri.ToString();
        DateTime countTime;
        map.TryGetValue(url, out countTime);
        Debug.Log(request.Uri.ToString() + ":" + response.DataAsText);
        TimeSpan t = DateTime.UtcNow - countTime;
        Debug.Log("comsumer  time ::" + t.Milliseconds);
    }}
