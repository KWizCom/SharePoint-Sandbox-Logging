using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace codeplex.spsl.sample.Logger_WebPart_Sample
{
	[ToolboxItemAttribute(false)]
	public class Logger_WebPart_Sample : WebPart
	{
		TextBox UserName;
		Button LogMessage;
		Label UserMessage;
		Logging logger;

		protected override void CreateChildControls()
		{
			logger = new Logging(this.GetType());

			UserName = new TextBox();
			LogMessage = new Button();
			LogMessage.Text = "Submit to log";
			LogMessage.Click += new EventHandler(LogMessage_Click);
			UserMessage = new Label();
			UserMessage.EnableViewState = false;

			this.Controls.Add(new LiteralControl("What is your name?"));
			this.Controls.Add(UserName);
			this.Controls.Add(LogMessage);
			this.Controls.Add(new LiteralControl("<hr />"));
			this.Controls.Add(UserMessage);
		}

		void LogMessage_Click(object sender, EventArgs e)
		{
			EnsureChildControls();

			if (logger.IsLoggingEnabled)
			{
				if (!string.IsNullOrEmpty(UserName.Text))
				{
					logger.LogInfo(UserName.Text + " has entered his name.");
					UserMessage.Text = "Hello " + UserName.Text;
				}
				else
				{
					logger.LogWarning("Suspicious activity logged. User provided empty name.");
					UserMessage.Text = "Blank name is not valid. A warning was logged.";
				}
			}
			else
				UserMessage.Text = "Logging is not enabled. Please activate the site colleciton SharePoint Sandbox Logging feature to enable logging, and provide write permissions for this user on the log list.";
		}

		protected override void OnInit(EventArgs e)
		{
			EnsureChildControls();

			base.OnInit(e);

			logger.LogInfo("Web part initialized");
		}

		protected override void OnLoad(EventArgs e)
		{
			EnsureChildControls();

			base.OnLoad(e);

			logger.LogInfo("Web part loaded");
		}

		protected override void OnPreRender(EventArgs e)
		{
			EnsureChildControls();

			base.OnPreRender(e);

			try
			{
				//Provoke an exception
				string s = null;
				s.ToString();
			}
			catch (Exception ex)
			{
				logger.LogError("Provoking error example", ex);
			}

			logger.LogInfo("Web part pre rendered");
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);

			logger.LogInfo("Web part rendered");

			if (logger.UnreportedErrors.Count > 0)
			{
				writer.WriteBreak();
				writer.WriteBreak();
				writer.Write("There were some errors that could not be reported to log list:<hr/>");
				foreach (var err in logger.UnreportedErrors)
				{
					writer.Write(err);
					writer.WriteBreak();
				}
			}
		}
	}
}
