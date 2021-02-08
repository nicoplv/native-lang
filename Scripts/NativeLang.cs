using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NativeLangs
{
	public class NativeLang 
	{
		[DllImport("__Internal")]
		private static extern string GetSysLang();

		public static string GetSystemLanguage()
		{
			#if UNITY_IOS && !UNITY_EDITOR
			return GetSysLang().Remove(2,3);
			#elif UNITY_ANDROID && !UNITY_EDITOR
			using(AndroidJavaClass localClass = new AndroidJavaClass(“java.util.Locale”))
			{
				if (localClass != null)
				{
					using (AndroidJavaObject locale = localClass.CallStatic<AndroidJavaObject>(“getDefault”))
					{
						if (locale != null)
						{
							return locale.Call<string>(“getLanguage”);
						}
					}
				}
			}
			#endif
			return "en";
		}

		public static string GetSystemCountry()
		{
			#if UNITY_IOS && !UNITY_EDITOR
			string syslang = GetSysLang();
			return syslang.Substring(Mathf.Max(0, syslang.Length - 2));
			#elif UNITY_ANDROID && !UNITY_EDITOR
			using(AndroidJavaClass localClass = new AndroidJavaClass(“java.util.Locale”))
			{
				if (localClass != null)
				{
					using (AndroidJavaObject locale = localClass.CallStatic<AndroidJavaObject>(“getDefault”))
					{
						if (locale != null)
						{
							return locale.Call<string>(“getCountry”);
						}
					}
				}
			}
			#endif
			return "US";
		}
	}
}