using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRunWatchLib
{
    public class SpeedRunWatch
    {
        private enum State
        {
            Running,
            Stop,
            Pause,
        }

        private State _state = State.Stop;
        private DateTime _realTime = DateTime.MaxValue;
        private DateTime _speedRunTime = DateTime.MaxValue;
        private DateTime _pauseTime = DateTime.MaxValue;
        private TimeSpan _speedRunSpan = TimeSpan.Zero;

        public string GetRealTime()
        {
            switch(_state)
            {
                case State.Stop:
                    return "Wait for start";

                default:
                    {
                        TimeSpan timeSpand = DateTime.Now - _realTime;
                        return FormmatTime(timeSpand);
                    }
            }
        }

        public string GetSpeedRunTime()
        {
            switch (_state)
            {
                case State.Stop:
                    return "Wait for start";

                case State.Pause:
                    return FormmatTime(_speedRunSpan);

                default:
                    {
                        TimeSpan timeSpand = DateTime.Now - _speedRunTime;
                        return FormmatTime(timeSpand + _speedRunSpan);
                    }
            }
        }

        private String FormmatTime(TimeSpan timeSpand)
        {
            return timeSpand.ToString("C");
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
