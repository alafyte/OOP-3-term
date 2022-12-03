using System;


namespace Lab19_20
{
    //Интерфейс команды
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    //Реализация интерфейса
    public class FlightOnCommand : ICommand
    {
        Flight Flight { get; set; }
        public FlightOnCommand(Flight flight)
        {
            Flight = flight;
        }

        public void Execute()
        {
            Flight.Add(Flight);
        }
        public void Undo()
        {
            Flight.Сanceled(Flight);
        }
    }
    //Получатель команды - Flight
    //Инициатор команды
    public class Admin
    {
        ICommand command;
        public Admin() { }
        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void AddNewFlight()
        {
            command.Execute();
        }
        public void CancelFlight()
        {
            command.Undo();
        }
    }
}
