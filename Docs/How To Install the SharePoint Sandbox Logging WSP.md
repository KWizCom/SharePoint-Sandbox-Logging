1. Download the "Recommended Download" from the Download Tab - this is a WSP
1. In Your SharePoint site - you must be a Site Administrator - Sign in
1. **Site Actions** | **Site settings** | **Go to top level site settings**
1. Under Galleries - the last item should be **Solutions** - click to go to the Solutions Gallery
1. Upload the WSP file that you downloaded from CodePlex
1. Activate the Solution in the Gallery - click on the Activate button in the ribbon of the popup window.
1. Ensure it says **Activated** in the status column - beside "SharePoint Sandbox Logging v1.1.00"
1. Return to **Site Actions** | **Site settings** - under site collection administration see **Site collection features** (about the 5th item) click on this
1. You should see **SharePoint Sandbox Logging** - they are in alphabetical order - click on the Activate Button
1. This will create the list at the Top level site - **Site Actions** | **View all Site content** - under lists you should see SharePoint Sandbox Log


Now you need a sandbox solution that provides logging support by including the codeplex.spsl.dll - and calling the methods on it. 

To turn off the logging, return to the **Site collection features** and deactivate the feature, but it will not remove the list itself. (you need to delete the list manually if you are done with it)

You can leave the wsp enabled in the solution gallery. It is the feature that needs to be enabled to allow the other sandbox solutions to log.
