# CSharp-Logger

A simple logging package that replicates python's logging library.

NuGet Package: https://www.nuget.org/packages/CSharp-Logger/1.0.1

# Installation

Just install the DLL from whatever version you choose and add it as a reference

# Usage

The api is accessed via the CSharp_Logger namespace. You'll mostly be working with Logger and LogFilter when using this.

For example, say you want to write only debug and warning messages to your log file (note that the file extension must be .log)
```c#
Logger logger = new Logger();
logger.SetConfiguration(@"...\my_log.log", LogFilter.Debug | LogFilter.Warning); // A directory path is also valid and will create a file named 'cs-log.log' by default

logger.Debug("Hello world!");
logger.Error("Oh no!");
logger.Warning("Just so you know...");
```

`Hello world!` and `Just so you know...` would be appended to your log file. `Oh no` would be ignored because it is not specified in your LogFilter bitmask.

You can also attatch a method to writer calls.

```c#
Loger logger = new Logger();

logger.CatchLog += MyLogCatcher;
```

CatchLog has two required parameters, `(Logger logger, CatchLogEvent args)`
CatchLogEvent exposes the type of log and message.

## Other stuff

You can use LogFilterFactory to generate LogFilters cleanly

The Logger class exposes a method, `ValidateFilePath`, which you can use to check whether or not a path is a valid log file.

The `InvalidLogFileException` is called when `ValidateFilePath` would otherwise return null. It is also called when you attempt to use a writer method (i.e, logger.Debug()) without first setting a log file.
