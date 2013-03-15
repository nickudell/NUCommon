using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MinWriter
{
    /// <summary>
    /// WPF-based timer that counts down from a provided time frame to 0.
    /// </summary>
    public class Countdown
    {
        #region Events
        public class TimerEventArgs : EventArgs
        {
            /// <summary>
            /// The milliseconds left on the countdown.
            /// </summary>
            private short milliseconds;

            /// <summary>
            /// Gets or sets the milliseconds left on the countdown.
            /// </summary>
            /// <value>
            /// The milliseconds left on the countdown.
            /// </value>
            public short Milliseconds
            {
                get { return milliseconds; }
                set { milliseconds = value; }
            }


            /// <summary>
            /// The seconds left on the countdown.
            /// </summary>
            private byte seconds;

            /// <summary>
            /// Gets or sets the seconds left on the countdown.
            /// </summary>
            /// <value>
            /// The seconds left on the countdown.
            /// </value>
            public byte Seconds
            {
                get { return seconds; }
                set { seconds = value; }
            }

            /// <summary>
            /// The minutes left on the countdown.
            /// </summary>
            private byte minutes;

            /// <summary>
            /// Gets or sets the minutes left on the countdown.
            /// </summary>
            /// <value>
            /// The minutes left on the countdown.
            /// </value>
            public byte Minutes
            {
                get { return minutes; }
                set { minutes = value; }
            }

            /// <summary>
            /// The hours left on the countdown.
            /// </summary>
            private byte hours;

            /// <summary>
            /// Gets or sets the hours left on the countdown.
            /// </summary>
            /// <value>
            /// The hours left on the countdown.
            /// </value>
            public byte Hours
            {
                get { return hours; }
                set { hours = value; }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TimerEventArgs"/> class with a value of 0 for the milliseconds, seconds, minutes and hours remaining values.
            /// </summary>
            public TimerEventArgs()
            {
                milliseconds = 0;
                seconds = 0;
                minutes = 0;
                hours = 0;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TimerEventArgs"/> class and fills the milliseconds, seconds, minutes and hours remaining values with the provided parameters.
            /// </summary>
            /// <param name="seconds">The seconds left on the countdown.</param>
            /// <param name="minutes">The minutes left on the countdown.</param>
            /// <param name="hours">The hours left on the countdown.</param>
            public TimerEventArgs(short milliseconds, byte seconds, byte minutes, byte hours)
            {
                this.milliseconds = milliseconds;
                this.seconds = seconds;
                this.minutes = minutes;
                this.hours = hours;
            }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents the time left
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents the number of hours, minutes, seconds and milliseconds remaining.
            /// </returns>
            public override string ToString()
            {
                return Convert.ToString(hours) + " hours, " + Convert.ToString(minutes) + " minutes, " + Convert.ToString(seconds) + " seconds and " + Convert.ToString(milliseconds) + " milliseconds remain.";
            }
        }

        /// <summary>
        /// Delegate for countdown timer events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimerEventArgs"/> instance containing the countdown timer event data.</param>
        public delegate void TimerEventDelegate(object sender, TimerEventArgs e);

        /// <summary>
        /// Occurs when the countdown reaches 0 seconds, minutes and hours.
        /// </summary>
        public event TimerEventDelegate Alarm;

        /// <summary>
        /// Occurs each timer tick.
        /// </summary>
        public event TimerEventDelegate Tick;

        #endregion
        #region Properties
        /// <summary>
        /// The milliseconds left on the countdown.
        /// </summary>
        private short milliseconds;

        /// <summary>
        /// Gets or sets the milliseconds left on the countdown.
        /// </summary>
        /// <value>
        /// The milliseconds left on the countdown.
        /// </value>
        public short Milliseconds
        {
            get { return milliseconds; }
            set { milliseconds = value; }
        }


        /// <summary>
        /// The seconds left on the countdown.
        /// </summary>
        private byte seconds;

        /// <summary>
        /// Gets or sets the seconds left on the countdown.
        /// </summary>
        /// <value>
        /// The seconds left on the countdown.
        /// </value>
        public byte Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        /// <summary>
        /// The minutes left on the countdown.
        /// </summary>
        private byte minutes;

        /// <summary>
        /// Gets or sets the minutes left on the countdown.
        /// </summary>
        /// <value>
        /// The minutes left on the countdown.
        /// </value>
        public byte Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        /// <summary>
        /// The hours left on the countdown.
        /// </summary>
        private byte hours;

        /// <summary>
        /// Gets or sets the hours left on the countdown.
        /// </summary>
        /// <value>
        /// The hours left on the countdown.
        /// </value>
        public byte Hours
        {
            get { return hours; }
            set { hours = value; }
        }
        #endregion

        private DispatcherTimer timer;

        public Countdown(TimeSpan interval)
        {
            timer = new DispatcherTimer();
            timer.Interval = interval;
            timer.Tick += tick;
        }

        public Countdown()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += tick;
        }

        /// <summary>
        /// Starts the countdown from the provided time.
        /// </summary>
        /// <param name="hours">The hours remaining.</param>
        /// <param name="minutes">The minutes remaining.</param>
        /// <param name="seconds">The seconds remaining.</param>
        /// <param name="milliseconds">The milliseconds remaining.</param>
        public void Start(byte hours, byte minutes, byte seconds, short milliseconds)
        {
            this.milliseconds = milliseconds;
            this.seconds = seconds;
            this.minutes = minutes;
            this.hours = hours;
            timer.Start();
        }

        /// <summary>
        /// Pauses the countdown.
        /// </summary>
        public void Pause()
        {
            timer.Stop();
        }

        /// <summary>
        /// Starts the countdown.
        /// </summary>
        public void Start()
        {
            timer.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            timer.Stop();
            milliseconds = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
        }

        /// <summary>
        /// Handles the timer's Tick event by counting down the values
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void tick(object sender, object e)
        {
            if (seconds == 0)
            {
                if (minutes == 0)
                {
                    if (hours == 0)
                    {
                        //Countdown has ended
                        if (Alarm != null)
                        {
                            Alarm(this, new TimerEventArgs());
                            timer.Stop();
                            return;
                        }
                    }
                    else
                    {
                        //Flip the minutes back to 59
                        hours--;
                        minutes = 59;
                    }
                }
                else
                {
                    minutes--;
                }
                //flip the seconds back to 59
                seconds = 59;
            }
            else
            {
                seconds--;
            }
            if (Tick != null)
            {
                Tick(this, new TimerEventArgs(milliseconds, seconds, minutes, hours));
            }
        }
    }
}
