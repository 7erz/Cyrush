using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_ItemCoinSaver : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ItemCoinSaver() : base(typeof(ItemCoinSaver)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ItemCoinSaver)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ItemCoinSaver)obj;
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


	public class ES3UserType_ItemCoinSaverArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemCoinSaverArray() : base(typeof(ItemCoinSaver[]), ES3UserType_ItemCoinSaver.Instance)
		{
			Instance = this;
		}
	}
}