using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace codeplex.spsl
{
	public class Logging
	{
		#region constants
		public const string C_LogListName = "SharePoint Sandbox Log";
		public const string C_LogFeatureID = "1e9e8401-cda9-4f22-9def-5df3784177a4";
		public const string C_LogList_Field_Source = "Message Source";
		public const string C_LogList_Field_Message = "Message Info";

		public const string C_LogList_Field_Type = "Message Type";
		public const string C_LogList_Field_Type_Error = "Error";
		public const string C_LogList_Field_Type_Warning = "Warning";
		public const string C_LogList_Field_Type_Info = "Info";
		#endregion

		SPSite _site = null;
		SPWeb _web = null;
		SPList _logList = null;
		string sourceTypeName = "";

		public List<string> UnreportedErrors = new List<string>();

		public Logging(Type source)
		{
			if (SPContext.Current != null && SPContext.Current.Site != null)
			{
				InitWithSite(SPContext.Current.Site, source);
			}
		}
		public Logging(SPSite site, Type source)
		{
			InitWithSite(site, source);
		}
		void InitWithSite(SPSite site)
		{
			InitWithSite(site, null);
		}
		void InitWithSite(SPSite site, Type source)
		{
			if (site == null) return;
			_site = site;

			if (this.IsLoggingEnabled)//if no logging
			{
				if (source != null)
				{
					sourceTypeName = source.FullName;
					this.LogInfo("Logger initialized");
				}

				_site.CatchAccessDeniedException = false;
				_site.AllowUnsafeUpdates = true;
				_web = _site.RootWeb;
				_web.AllowUnsafeUpdates = true;
				_web.Lists.ListsForCurrentUser = true;
				_logList = _web.Lists.TryGetList(C_LogListName);
			}
		}

		bool? isEnabled;
		public bool IsLoggingEnabled
		{
			get
			{
				if (isEnabled.HasValue) return isEnabled.Value;
				try
				{
					//check if feature is active in this site collection
					if (_site != null)
					{
						if (_site.Features[new Guid(C_LogFeatureID)] != null)//we got our feature
						{
							isEnabled = true;
							return true;
						}
					}
					isEnabled = false;
					return false;
				}
				catch(Exception ex)
				{
					UnreportedErrors.Add(ex.ToString());
					return false;
				}
			}
		}

		public void LogError(Exception ex)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(sourceTypeName, ex.ToString(), C_LogList_Field_Type_Error);
		}
		public void LogError(string message, Exception ex)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(sourceTypeName, message + " " + ex.ToString(), C_LogList_Field_Type_Error);
		}
		public void LogError(string source, string message, Exception ex)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(source, message + " " + ex.ToString(), C_LogList_Field_Type_Error);
		}
		public void LogError(string message)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(sourceTypeName, message, C_LogList_Field_Type_Error);
		}
		public void LogError(string source, string message)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(source, message, C_LogList_Field_Type_Error);
		}
		public void LogWarning(string message)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(sourceTypeName, message, C_LogList_Field_Type_Warning);
		}
		public void LogWarning(string source, string message)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(source, message, C_LogList_Field_Type_Warning);
		}
		public void LogInfo(string message)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(sourceTypeName, message, C_LogList_Field_Type_Info);
		}
		public void LogInfo(string source, string message)
		{
			if (!IsLoggingEnabled) return;
			CreateItem(source, message, C_LogList_Field_Type_Info);
		}

		void CreateItem(string source, string message, string type)
		{
			string timestamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
			if (!IsLoggingEnabled) return;
			try
			{
				if (_logList != null)
				{
					SPListItem item = _logList.Items.Add();
					item["Title"] = timestamp;
					item[C_LogList_Field_Message] = message;
					item[C_LogList_Field_Source] = source;
					item[C_LogList_Field_Type] = type;
					item.Update();
				}
			}
			catch(Exception ex)
			{
				UnreportedErrors.Add(ex.ToString());
			}
		}
	}
}
