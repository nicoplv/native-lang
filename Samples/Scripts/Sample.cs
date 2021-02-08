using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NativeLangs.Samples
{
	public class Sample : MonoBehaviour
	{
	    public Text textLangue = null;
	    public Text textCountry = null;

	    void Start()
	    {
	        textLangue.text = NativeLang.GetSystemLanguage();
	        textCountry.text = NativeLang.GetSystemCountry();
	    }
	}
}