using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterHandler : MonoBehaviour
{
	public void OpenTwitterURL ()
	{
		string twitterAddress = "http://twitter.com/intent/tweet";

		string message = "Get this awesome game now!";

		string descriptionParameter = "Space Face";

		string appStoreLink = "https://play.google.com/store/apps/details?id=com.growlgamesstudio.pizZapMania";

		Application.OpenURL (twitterAddress + "?text=" + WWW.EscapeURL (string.Format ("{0} by {1}. {2}", message, descriptionParameter, appStoreLink)));
	}
}