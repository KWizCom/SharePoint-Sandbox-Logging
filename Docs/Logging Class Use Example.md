# Constructors
## Create logger instance
```
using codeplex.spsl;
....
Logging logger;

....
logger = new Logging(this.GetType());
```

> note - this will pick the SpSite from the SpContext, but this will not work if you are logging in an event receiver during feature activation. Also note that this.GetType() may be quite a long string, you may want to provide a shorter string constant to identify the component that is logging

## Create logger instance in a FeatureActivated EventReceiver
```
using codeplex.spsl;
....
Logging logger;

....
using (SPSite site = properties.Feature.Parent as SPSite)
{
    logger = new Logging(site, this.GetType());
    ....
```

## Create logger instance in a FeatureUninstalling EventReceiver
```
using codeplex.spsl;
....
Logging logger;

....
 using (SPSite site = properties.UserCodeSite.EventReceivers.Site)
{
    logger = new Logging(site, this.GetType());
    ...
```

# Code samples
## Check if logging is enabled (feature is active)
```
if (logger.IsLoggingEnabled)
{
    // code here
}
```

> note - you don't normally need to do this, if logging is not enabled, nothing bad should happen. the Logged messages will be lost

## Log Info

```
logger.LogInfo("Info text");
```

## Log Warning
```
logger.LogWarning("Suspicious activity logged.");
```

## Log Error (with an exception)
```
logger.LogError("Provoking error example", ex);
```

## Handling and showing errors that the logger could not report to log list
```
if (logger.UnreportedErrors.Count > 0) 
{
  foreach (var err in logger.UnreportedErrors) 
     { ... do something ... }
}
```

> note that UnreportedErrors, only get captured, if Logging is enabled, but there is an error logging to the list. If logging is not enabled, the UnreportedErrors remain 0.
