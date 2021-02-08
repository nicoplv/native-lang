using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;

namespace NativeLangs
{
	public class NativeLang 
	{
		[DllImport("__Internal")]
		private static extern string GetSysLang();

		public static string GetSystemLanguage()
		{
			#if UNITY_IOS && !UNITY_EDITOR
			string syslang = GetSysLang();
			string[] syslangs = syslang.Split(new char[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
			if(syslang.Length > 0)
				return syslangs[0];
			#elif UNITY_ANDROID && !UNITY_EDITOR
			using(AndroidJavaClass localClass = new AndroidJavaClass("java.util.Locale"))
			{
				if (localClass != null)
				{
					using (AndroidJavaObject locale = localClass.CallStatic<AndroidJavaObject>("getDefault"))
					{
						if (locale != null)
						{
							return locale.Call<string>("getLanguage");
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
			string[] syslangs = syslang.Split(new char[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
			if(syslang.Length > 1)
				return syslangs[1];
			#elif UNITY_ANDROID && !UNITY_EDITOR
			using(AndroidJavaClass localClass = new AndroidJavaClass("java.util.Locale"))
			{
				if (localClass != null)
				{
					using (AndroidJavaObject locale = localClass.CallStatic<AndroidJavaObject>("getDefault"))
					{
						if (locale != null)
						{
							return locale.Call<string>("getCountry");
						}
					}
				}
			}
			#endif
			return "US";
		}
	}
}