using UnityEngine;
using System.Collections;

public interface LoadAPIListenner
{
	void onLoadSucess (string result, string API_NAME);

	void onLoadFail (string result, string API_NAME);

}
