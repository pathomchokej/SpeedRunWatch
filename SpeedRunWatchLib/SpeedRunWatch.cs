using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRunWatchLib
{
    public class SpeedRunWatch
    {
        public enum State
        {
            Running,
            Stop,
            Pause,
        }

        public State ControlState => _state;

        private State _state = State.Stop;
        private DateTime _realTime = DateTime.MaxValue;
        private DateTime _speedRunTime = DateTime.MaxValue;
        private DateTime _pauseTime = DateTime.MaxValue;
        private TimeSpan _speedRunSpan = TimeSpan.Zero;

        public void GetTime(out string realTime, out string speedRunTime)
        {
            DateTime currentTime = DateTime.Now;

            switch (_state)
            {
                case State.Stop:
                    realTime = "Wait for start";
                    speedRunTime = "Wait for start";
                    break;

                case State.Pause:
                    {
                        TimeSpan realtimeSpand = currentTime - _realTime;
                        realTime = FormmatTime(realtimeSpand);

                        speedRunTime = FormmatTime(_speedRunSpan);
                    }
                    break;

                default:
                    {
                        TimeSpan realtimeSpand = currentTime - _realTime;
                        realTime = FormmatTime(realtimeSpand);

                        TimeSpan timeSpand = currentTime - _speedRunTime;
                        speedRunTime = FormmatTime(timeSpand + _speedRunSpan);
                    }
                    break;
            }
        }

        private String FormmatTime(TimeSpan timeSpand)
        {
            return timeSpand.ToString("c");
        }

        public void Start()
        {
            if(_state == State.Stop)
            {
                _realTime = DateTime.Now;
                _speedRunTime = _realTime;
                _pauseTime = DateTime.MaxValue;
                _speedRunSpan = TimeSpan.Zero;
                _state = State.Running;
            }
        }

        public void Stop()
        {
            _realTime = DateTime.MaxValue;
            _speedRunTime = _realTime;
            _state = State.Stop;
        }

        public void Pause()
        {
            if (_state == State.Running)
            {
                _pauseTime = DateTime.Now;
                _speedRunSpan += _pauseTime - _speedRunTime;
                _state = State.Pause;
            }
        }

        public void Resume()
        {
            if (_state == State.Pause)
            {
                _speedRunTime = DateTime.Now;
                _state = State.Running;
            }
        }
    }
}
