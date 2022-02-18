﻿namespace Meziantou.Framework.Templating
{
    public class Output
    {
        public Template Template { get; }
        public TextWriter Writer { get; }

        public Output(Template template!!, TextWriter writer!!)
        {
            Template = template;
            Writer = writer;
        }

        public virtual void Write(object? value)
        {
            Write("{0}", value);
        }

        public virtual void Write(string? value)
        {
            Write("{0}", value);
        }

        public virtual void Write(string format, params object?[] args)
        {
            Writer.Write(format, args);
        }
    }
}
