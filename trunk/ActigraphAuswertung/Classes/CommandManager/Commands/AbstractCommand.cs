using System;

namespace ActigraphAuswertung.CommandManager.Commands
{
    /// <summary>
    /// Callback definition for successful commands.
    /// </summary>
    /// <param name="result">The result of the command, returned by <see cref="AbstractCommand.execute"/></param>
    public delegate void CommandFinishedDelegate(object result);

    /// <summary>
    /// Abstract base class for all commands. This class provides 
    /// the basic structure for command priority, a callback being called if
    /// the command was successfull, a command description and an entry point 
    /// for command execution.
    /// </summary>
    abstract class AbstractCommand
    {
        protected Priority priority = Priority.VeryLow;

        /// <summary>
        /// The priority of this command. Used by the <see cref="Manager"/> 
        /// to determine the command execution order.
        /// </summary>
        public Priority Priority
        {
            get { return this.priority; }
        }

        private CommandFinishedDelegate callback;

        /// <summary>
        /// The function to be called if the command was executed successful.
        /// Called by the <see cref="Manager"/> with the result of this command.
        /// </summary>
        public CommandFinishedDelegate Callback
        {
            get { return this.callback; }
        }

        protected String description;

        /// <summary>
        /// The Description of the command.
        /// </summary>
        public String Description
        {
            get { return this.description; }
        }

        /// <summary>
        /// Constructor for the command.
        /// </summary>
        /// <param name="priority">The priority for the command</param>
        /// <param name="callback">The callback for the command</param>
        public AbstractCommand(Priority priority, CommandFinishedDelegate callback)
        {
            this.priority = priority;
            this.callback = callback;
        }

        /// <summary>
        /// Execution entry point for commands. Result is the only parameter of the callback.
        /// </summary>
        /// <returns>The result of the command (if any)</returns>
        abstract public object execute();
    }
}
