using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageButton : MonoBehaviour
{
    private Text label;

    void Start() {
        label = this.gameObject.GetComponentInChildren<Text>();
        
        label.text = label.text == "SignIn" ? "SignOut" : "SignIn";
        
        // IDToken取得
        // 取得できれば SignOut 、できなければ SingIn を表示する
        FirebaseAuthPlugIn.CallPlugin(OnEndOfGetIDToken);

    }

    public void OnClickButton() {
        if (label.text == "SignIn") {
            // SignIn実行
            ManageScroll.Log(DateTime.Now.ToString("tthh時mm分ss秒fffミリ秒") + ": SignIn");
            GoogleSignInPlugIn.SignIn();
            label.text = "SignOut";
        } else {
            // SignOut実行
            ManageScroll.Log(DateTime.Now.ToString("tthh時mm分ss秒fffミリ秒") + ": SignOut");
            GoogleSignInPlugIn.SignOut();
            label.text = "SignIn";
        }
    }
    
    private void OnEndOfGetIDToken(string token, string err) {
        Debug.Log("token: " + token);
        Debug.Log("err: " + err);

        if (err == "" && token != "") {
            // SingIn済み
            ManageScroll.Log("token: " + token);
            label.text = "SignOut";
        }

        if (err != "") {
            ManageScroll.Log("err: " + err);
            label.text = "SignIn";
        }        
    }
}
