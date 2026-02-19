using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("bebtnID", "enabled")]
	public class ES3UserType_ButtonInfoID : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ButtonInfoID() : base(typeof(ButtonInfoID)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ButtonInfoID)obj;
			
			writer.WriteProperty("bebtnID", instance.bebtnID, ES3Type_int.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ButtonInfoID)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "bebtnID":
						instance.bebtnID = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ButtonInfoIDArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ButtonInfoIDArray() : base(typeof(ButtonInfoID[]), ES3UserType_ButtonInfoID.Instance)
		{
			Instance = this;
		}
	}
}