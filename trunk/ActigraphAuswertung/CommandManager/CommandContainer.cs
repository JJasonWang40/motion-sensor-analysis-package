using System;
using System.ComponentModel;
using ActigraphAuswertung.CommandManager.Commands;

namespace ActigraphAuswertung.CommandManager
{
    /// <summary>
    /// A facade like container for commands. Abstracts backgroundworker handling for 
    /// commands and manages the command's status and error messages. Implements
    /// <see cref="INotifyPropertyChanged"/> to be able to inform binding objects of 
    /// changes to the command's status.
    /// </summary>
    class CommandContainer : INotifyPropertyChanged
    {
        /// <summary>
        /// Event called when the command's status or message have changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private Status status;

        /// <summary>
        /// The command's status. Fires <see cref="PropertyChangedEventHandler"/> when changed.
        /// </summary>
        public Status Status
        {
            get { return this.status; }
            set { 
                this.status = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }

        private String message;

        /// <summary>
        /// The command's (error) message. Fires <see cref="PropertyChangedEventHandler"/> when changed.
        /// </summary>
        public String Message
        {
            get { return this.message; }
            set {
                this.message = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
                }
            }
        }

        private AbstractCommand command;

        /// <summary>
        /// The command encapsulated.
        /// </summary>
        public AbstractCommand Command
        {
            get { return this.command; }
        }

        /// <summary>
        /// The description of the encapsulated command.
        /// </summary>
        public String Description
        {
            get { return this.command.Description; }
        }

        /// <summary>
        /// The priority of the encapsulated command.
        /// </summary>
        public Priority Priority
        {
            get { return this.command.Priority; }
        }

        /// <summary>
        /// Constructor. Set's the command's status to <see cref="CommandManager.Status.Waiting"/>
        /// </summary>
        /// <param name="command">The command to be encapsulated</param>
        public CommandContainer(AbstractCommand command)
        {
            this.command = command;
            this.status = Status.Waiting;
        }

        /// <summary>
        /// The execution entry for the backgroundworker. Encapsulates backgroundworker
        /// logic for the command.
        /// </summary>
        /// <param name="sender">The calling backgroundworker</param>
        /// <param name="args"></param>
        public void runCommand(object sender, DoWorkEventArgs args)
        {
            // Assign the result of the command to the backgroundworker's result.
            object result = this.command.execute();
            args.Result = result;
        }
    }
}
