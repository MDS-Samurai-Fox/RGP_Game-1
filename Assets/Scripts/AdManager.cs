using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
// #if UNITY_ANDROID
	string gameID = "1807882";
// #elif UNITY_IOS
	// string gameID = "1807883";
// #endif

	void Awake ()
	{
		Advertisement.Initialize (gameID, true);
	}

	public void ShowAd (string placementID = "")
	{
#if UNITY_EDITOR
		StartCoroutine (WaitForAd ());
#endif

		if (string.Equals (placementID, ""))
			placementID = null;

		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady (placementID))
			Advertisement.Show (placementID, options);
	}

	void AdCallbackhandler (ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log ("Ad Finished. Rewarding player...");
				OnAdFinished ();
				break;
			case ShowResult.Skipped:
				Debug.Log ("Ad skipped. Son, I am dissapointed in you");
				OnAdSkipped ();
				break;
			case ShowResult.Failed:
				Debug.Log ("I swear this has never happened to me before");
				OnAdFailed ();
				break;
		}
	}

	protected virtual void OnAdFinished ()
	{

	}

	protected virtual void OnAdSkipped ()
	{

	}

	protected virtual void OnAdFailed ()
	{

	}

	IEnumerator WaitForAd ()
	{
		Debug.Log ("Waiting for ad");

		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;

		while (Advertisement.isShowing)
			yield return null;

		Time.timeScale = currentTimeScale;
	}
}