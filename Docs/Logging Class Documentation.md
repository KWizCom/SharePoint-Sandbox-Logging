# Class name: public class Logging

## Namespace: codeplex.spsl

## Constants

### public const string C_LogListName = "SharePoint Sandbox Log";
### public const string C_LogFeatureID = "1e9e8401-cda9-4f22-9def-5df3784177a4";
### public const string CLogListField_Source = "Message Source";
### public const string CLogListField_Message = "Message Info";
### public const string CLogListField_Type = "Message Type";
### public const string CLogListFieldTypeError = "Error";
### public const string CLogListFieldTypeWarning = "Warning";
### public const string CLogListFieldTypeInfo = "Info";

## Public Members
### public List<string> UnreportedErrors = new List<string>();

A collection that holds all errors from the logging class that were not reported to log list, such as user does not have access to write to log list, or log list does not exist.

## Public Properties
### public bool IsLoggingEnabled

Lazy property, meaning the check will be done only once and subsequent calls to this property will return a private member with the result.

## Constractors
### public Logging(Type source)

Init with current context site
### public Logging(SPSite site, Type source)
### void InitWithSite(SPSite site)
### void InitWithSite(SPSite site, Type source)

## Public Methods
### public void LogError(Exception ex)
### public void LogError(string message, Exception ex)
### public void LogError(string source, string message, Exception ex)
### public void LogError(string message)
### public void LogError(string source, string message)
### public void LogWarning(string message)
### public void LogWarning(string source, string message)
### public void LogInfo(string message)
### public void LogInfo(string source, string message)

---
If you need more info on a specific member / method please submit a question in the issue tracker.
