using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_CoinShow : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CoinShow() : base(typeof(CoinShow)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (CoinShow)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (CoinShow)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CoinShowArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CoinShowArray() : base(typeof(CoinShow[]), ES3UserType_CoinShow.Instance)
		{
			Instance = this;
		}
	}
}