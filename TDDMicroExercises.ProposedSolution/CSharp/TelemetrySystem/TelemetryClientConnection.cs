using System;

namespace TDDMicroExercises.OneSolution.TelemetrySystem
{
    public class TelemetryClientConnection : IConnection
    {
        private bool _onlineStatus;
        private readonly Random _connectionEventsSimulator = new Random();

        public bool OnlineStatus
        {
            get { return _onlineStatus; }
        }

        public void Connect(string telemetryServerConnectionString)
        {
            if (string.IsNullOrEmpty(telemetryServerConnectionString))
            {
                throw new ArgumentNullException();
            }

            // Fake the connection with 20% chances of success
            bool success = _connectionEventsSimulator.Next(1, 10) <= 2;

            _onlineStatus = success;
        }

        public void Disconnect()
        {
            _onlineStatus = false;
        }
    }
}
