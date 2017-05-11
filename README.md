# SharePoint-Sandbox-Logging

SharePoint Sandbox Logging enables developers and solution designers to easily log events to logging list in your site collection, allowing you to easily trace errors on custom solutions within your site collection, with no need for server access.
Perfect for sandbox / Office365.

This project contains one sandbox solution with a site collection logging feature. When feature is active - it creates the list and logs. If it is not active - it does not log. Simple.

It also contains a sample C# class for using the logger. You should use this class within your solution and use it to do your logging.

This project is for public free use, the goal is to create a community standard for logging in SharePoint from sandbox solutions, and also from full trusted solutions if you want to!

Use the discussion board for changes / new features requests, or ask to join if you wish to contribute.

## Documentation

See [Logging Class Use Example](https://github.com/KWizCom/SharePoint-Sandbox-Logging/blob/master/Docs/Logging%20Class%20Use%20Example.md)

See [Logging Class Documentation](https://github.com/KWizCom/SharePoint-Sandbox-Logging/blob/master/Docs/Logging%20Class%20Documentation.md)

## Why did i build this project?

Quote from SharePoint Online for Office 365: Developer Guide (http://www.microsoft.com/downloads/en/details.aspx?FamilyID=4387e030-73dc-48e7-ac95-abc043b9335a):

> Outputting Debug Information in SharePoint Online
> 
> You can further validate the operations being performed in the actual SharePoint Online environment by conditionally creating list items in SharePoint lists, based on any information that you want to interrogate at run time. In effect, you can use SharePoint lists as a custom application log that can help you analyze the operations, exceptions, and performance of your solutions.
> 
> If you take this approach, you should consider the implications of creating a large number of list items on your SharePoint Online storage quotas. For example, a good pattern is to conditionally create list items for your data only in the DEBUG configuration of your solution, and to deploy the DEBUG build only to your test site collections. Then, when you are satisfied that your solution is functioning correctly, you can deploy the RELEASE configuration to your production site collections, and you will not use storage quotas needlessly in that environment.

---
This project is brought to you by KWizCom corporation, with full source code.


Please visit us http://www.kwizcom.com


Migrated to GitHub May 11 2017
