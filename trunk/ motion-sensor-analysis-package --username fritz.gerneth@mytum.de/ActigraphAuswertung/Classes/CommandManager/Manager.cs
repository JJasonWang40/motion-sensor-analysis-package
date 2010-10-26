using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ActigraphAuswertung.CommandManager.Commands;

namespace ActigraphAuswertung.CommandManager
{
    /// <summary>
    /// Class for managing commands and executing them in the background.
    /// </summary>
    class Manager
    {
        // see MaxThreadsRunning
        private int maxThreadsRunning;

        // count of currently running threads
        private int currentThreadsRunning;

        // Dictionary to be able to resolve the finished backgroundworker to the commandcontainer it was associated with
        private Dictionary<BackgroundWorker, CommandContainer> runningThreads = new Dictionary<BackgroundWorker, CommandContainer>();

        // BindingList of all commands. (BindingList to be able to notify changes)
        private BindingList<CommandContainer> commands = new BindingList<CommandContainer>();

        /// <summary>
        /// All commands the command-manager is aware of.
        /// </summary>
        public BindingList<CommandContainer> Commands
        {
            get { return this.commands; }
        }

        /// <summary>
        /// Number of commands that may run at the same time.
        /// </summary>
        public int MaxThreadsRunning
        {
            get { return this.maxThreadsRunning; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maxThreadsRunning">Maximum number of commands running at the same time.</param>
        public Manager(int maxThreadsRunning)
        {
            this.maxThreadsRunning = maxThreadsRunning;
        }

        /// <summary>
        /// Constructor. Sets the number of maximum running commands to the processor count.
        /// </summary>
        public Manager() : this(Environment.ProcessorCount)
        {  
        }

        /// <summary>
        /// Adds a command to the manager. 
        /// </summary>
        /// <param name="command">The command to be executed.</param>
        public void addCommand(AbstractCommand command)
        {
            // Encapsulate the command and try to start the next command
            this.commands.Add(new CommandContainer(command));
            this.nextCommand();
        }

        /// <summary>
        /// Starts the next command (if any).
        /// </summary>
        private void nextCommand()
        {
            // Check if we can start new threads.
            if (this.runningThreads.Count >= this.maxThreadsRunning)
            {
                return;
            }

            // Get next Waiting command with highest priority
            CommandContainer next = this.commands.AsQueryable()
                 .OrderByDescending(s => s.Priority)
                 .FirstOrDefault<CommandContainer>(s => s.Status == Status.Waiting);

            // Check for no further commands
            if (next == null)
            {
                return;
            }

            // Set the command's status to running and increate the running command count
            next.Status = Status.Running;
            this.currentThreadsRunning++;

            // Init and start the backgroundworker for the command
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += next.runCommand;
            worker.RunWorkerCompleted += this.onWorkerCompleted;
            worker.RunWorkerAsync(next);

            // Add backgroundworker and commandcontainer to the list of running commands
            this.runningThreads.Add(worker, next);
        }

        /// <summary>
        /// Called by a backgorundworker when the command is completed or an exception was caught.
        /// Sets the command's status and message according to the result and calls the command's 
        /// callback if the execution was successful.
        /// Starts the next command (if any).
        /// </summary>
        /// <param name="sender">The finished backgroundworker.</param>
        /// <param name="args"></param>
        private void onWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            // Get backgroundworker's associated commandcontainer
            CommandContainer commandContainer = this.runningThreads[sender as BackgroundWorker];
            
            // Check if did catch any exceptions
            if (args.Error != null)
            { 
                // Set Status to Status.Error and set the exception message as the command's message
                commandContainer.Status = Status.Error;
                commandContainer.Message = args.Error.ToString();
            } else {
                // Command successful. Set status to Status.Finished and call the 
                // successfull-callack with the command's result
                commandContainer.Status = Status.Finished;
                commandContainer.Command.Callback(args.Result);
            }

            // Remove the backgroundworker and it's commandcontainer from the running list
            this.runningThreads.Remove(sender as BackgroundWorker);
            // Decrease running commands counter and start the next command
            this.currentThreadsRunning--;
            this.nextCommand();
        }
    }
}