﻿namespace Kanbersky.Ocelot.Core.Logging
{
    public class LogTemplates
    {
        public static readonly string Error = $"ERROR: HTTP {"{" + nameof(LoggerModel.RequestMethod) + "}"} / {"{" + nameof(LoggerModel.RequestPathAndQuery) + "}"} responded as {"{" + nameof(LoggerModel.ResponseStatusCode) + "}"}";

        public static readonly string BadRequest = $"BAD REQUEST: HTTP {"{" + nameof(LoggerModel.RequestMethod) + "}"} / {"{" + nameof(LoggerModel.RequestPathAndQuery) + "}"} responded as {"{" + nameof(LoggerModel.ResponseStatusCode) + "}"}";
    }
}
