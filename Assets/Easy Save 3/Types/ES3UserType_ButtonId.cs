using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("isBuy", "btnID")]
	public class ES3UserType_ButtonId : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ButtonId() : base(typeof(ButtonId)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ButtonId)obj;
			
			writer.WriteProperty("isBuy", instance.isBuy, ES3Type_bool.Instance);
			writer.WriteProperty("btnID", instance.btnID, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ButtonId)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "isBuy":
						instance.isBuy = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "btnID":
						instance.btnID = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ButtonIdArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ButtonIdArray() : base(typeof(ButtonId[]), ES3UserType_ButtonId.Instance)
		{
			Instance = this;
		}
	}
}