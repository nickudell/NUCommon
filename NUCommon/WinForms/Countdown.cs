using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Contracts;

namespace Common.WinForms
{
    /// <summary>
    /// WPF-based timer that counts down from a provided time frame to 0.
    /// </summary>
    public class Countdown
    {
        #region Events
        public class TimerEventArgs : EventArgs
        {
            private ulong ticks;

            public ulong Ticks
            {
                get { return ticks; }
                set { ticks = value; }
            }
            

            /// <summary>
            /// The milliseconds left on the countdown.
            /// </summary>
            private ushort milliseconds;

            /// <summary>
            /// Gets or sets the milliseconds left on the countdown.
            /// </summary>
            /// <value>
            /// The milliseconds left on the countdown.
            /// </value>
            public ushort Milliseconds
            {
                get {
                    Contract.Ensures(Contract.Result<ushort>() >= 0);
                    return milliseconds; 
                }
                set {
                    Contract.Requires<ArgumentException>(value >= 0, "Milliseconds must not be negative.");
                    milliseconds = value; 
                }
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
                get {
                    return seconds; 
                }
                set {
                    seconds = value; 
                }
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
                get {
                    return minutes; 
                }
                set {
                    minutes = value; 
                }
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

            private ulong days;

            public ulong Days
            {
                get { return days; }
                set { days = value; }
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
            public TimerEventArgs(ulong ticks)
            {
                this.ticks = ticks;
                this.milliseconds = (ushort)(ticks % 1000);
                this.seconds = (byte)((ticks % 60000) / 1000);
                this.minutes = (byte)((ticks % 3600000) / 60000);
                this.hours = (byte)((ticks % 86400000) / 3600000);
                this.days = (ulong)(ticks / 86400000);
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
        /// Gets or sets the milliseconds left on the countdown.
        /// </summary>
        /// <value>
        /// The milliseconds left on the countdown.
        /// </value>
        public ushort Milliseconds
        {
            get
            {
                Contract.Ensures(Contract.Result<ushort>() >= 0);
                Contract.Ensures(Contract.Result<ushort>() < 1000);
                return (ushort)(ticks % 1000);
            }
        }

        /// <summary>
        /// Gets or sets the seconds left on the countdown.
        /// </summary>
        /// <value>
        /// The seconds left on the countdown.
        /// </value>
        public byte Seconds
        {
            get
            {
                Contract.Ensures(Contract.Result<byte>() >= 0);
                Contract.Ensures(Contract.Result<byte>() < 60);
                return (byte)((ticks % 60000)/1000);
            }
        }

        /// <summary>
        /// Gets or sets the minutes left on the countdown.
        /// </summary>
        /// <value>
        /// The minutes left on the countdown.
        /// </value>
        public byte Minutes
        {
            get
            {
                Contract.Ensures(Contract.Result<byte>() >= 0);
                Contract.Ensures(Contract.Result<byte>() < 60);
                return (byte)((ticks % 3600000) / 60000);
            }
        }

        /// <summary>
        /// Gets or sets the hours left on the countdown.
        /// </summary>
        /// <value>
        /// The hours left on the countdown.
        /// </value>
        public byte Hours
        {
            get
            {
                Contract.Ensures(Contract.Result<byte>() >= 0);
                Contract.Ensures(Contract.Result<byte>() < 24);
                return (byte)((ticks % 86400000) / 3600000);
            }
        }

        /// <summary>
        /// Gets or sets the days left on the countdown.
        /// </summary>
        /// <value>
        /// The days left on the countdown.
        /// </value>
        public ulong Days
        {
            get
            {
                Contract.Ensures(Contract.Result<ushort>() >= 0);
                return (ulong)(ticks / 86400000);
            }
        }
        #endregion

        /// <summary>
        /// The milliseconds remaining until the alarm fires
        /// </summary>
        private ulong ticks;

        /// <summary>
        /// The internal timer
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Countdown"/> class.
        /// </summary>
        /// <param name="interval">The tick interval.</param>
        public Countdown(TimeSpan interval)
        {
            timer = new Timer();
            timer.Interval = interval.Duration().Milliseconds;
            timer.Tick += tick;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Countdown"/> class with a tick interval of 1.
        /// </summary>
        public Countdown() : this(TimeSpan.FromMilliseconds(1))
        {
        }

        /// <summary>
        /// Starts the countdown from the provided time.
        /// </summary>
        /// <param name="hours">The hours remaining.</param>
        /// <param name="minutes">The minutes remaining.</param>
        /// <param name="seconds">The seconds remaining.</param>
        /// <param name="milliseconds">The milliseconds remaining.</param>
        public void Start(ulong days, byte hours, byte minutes, byte seconds, ushort milliseconds)
        {
            Contract.Requires<ArgumentException>(days <= 213503982334ul,"Days cannot be larger than 213503982335.");
            Contract.Requires<ArgumentException>(hours < 24, "Hours cannot be larger than 23.");
            Contract.Requires<ArgumentException>(minutes <60,"Minutes cannot be larger than 59.");
            Contract.Requires<ArgumentException>(seconds < 60, "Seconds cannot be larger than 59.");
            Contract.Requires<ArgumentException>(milliseconds < 1000, "Milliseconds cannot be larger than 999");
            ticks = days *86400000ul + hours * 3600000ul + minutes * 60000ul + seconds * 1000ul;
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
            ticks = 0;
        }

        /// <summary>
        /// Handles the timer's Tick event by counting down the values
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void tick(object sender, object e)
        {
            if (ticks <= (ulong)timer.Interval)
            {
                Alarm(this, new TimerEventArgs());
                Stop();
            }
            else
            {
                ticks = ticks - (ulong)timer.Interval;
            }
            if (Tick != null)
            {
                Tick(this, new TimerEventArgs(ticks));
            }
        }
    }
}
