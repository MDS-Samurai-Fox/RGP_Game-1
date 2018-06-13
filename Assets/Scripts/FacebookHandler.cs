using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System.Linq;

public class FacebookHandler : MonoBehaviour
{
	void Awake()
	{
		if (!FB.IsInitialized)
		{
			FB.Init();
		}
		else
		{
			FB.ActivateApp();
		}
	}
	public void Share()
	{
		if (FB.IsLoggedIn)
		{
			FB.ShareLink(contentTitle: "Afterglow",
			contentURL: new System.Uri("http://www.afterglow.studio"),
			contentDescription: "Like and Share my page", callback: onShare);
		}
		else
		{
			Debug.Log("User Not Logged In"); FB.LogInWithReadPermissions(null,callback: onLogin);
		}
	}

	private void onLogin(ILoginResult result)
	{
		if (result.Cancelled)
		{
			Debug.Log(" user cancelled login");
		}
		else
		{
			Share(); // call share() again
		}
	}
	private void onShare(IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
		{
			Debug.Log("sharelink error: " + result.Error);
		}
		else if (!string.IsNullOrEmpty(result.PostId))
		{
			Debug.Log("link shared");
		}
	}
}