
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	internal delegate void TimerCallback(object state);

	/// <summary>
	/// Added:
	///		Microsoft.Threading.Tasks
	///		Microsoft.Threading.Tasks.Extensions
	///			System.IO
	///			System.Runtime
	///			System.Threading.Tasks
	/// </summary>
	public sealed class Timer : System.Threading.CancellationTokenSource, IDisposable
	{
		internal Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
		{
			System.Diagnostics.Contracts.Contract.Assert
				(
				  period == TimeSpan.FromMilliseconds(-1)
				, "This stub implementation only supports dueTime."
				);
			Task.Delay(dueTime, Token).ContinueWith
				(
					(t, s) =>
						{
							var tuple = (Tuple<TimerCallback, object>)s;
							tuple.Item1(tuple.Item2);
						}
					, Tuple.Create(callback, state)
					, System.Threading.CancellationToken.None
					, TaskContinuationOptions.ExecuteSynchronously 
					  | 
					  TaskContinuationOptions.OnlyOnRanToCompletion
					, TaskScheduler.Default
				);
		}

		public new void Dispose() { base.Cancel(); }
	}
	public class PCLTimer
	{
		private Timer _timer;
		private TimeSpan _interval;

		/// <summary>
		/// Interval between signals in milliseconds.
		/// </summary>
		public double Interval
		{
			get { return _interval.TotalMilliseconds; }
			set { _interval = TimeSpan.FromMilliseconds(value); Stop(); Start(); }
		}

		/// <summary>
		/// True if PCLTimer is running, false if not.
		/// </summary>
		public bool Enabled
		{
			get { return null != _timer; }
			set { if (value) Start(); else Stop(); }
		}

		/// <summary>
		/// Occurs when the specified time has elapsed and the PCLTimer is enabled.
		/// </summary>
		public event EventHandler Elapsed;

		/// <summary>
		/// Starts the PCLTimer.
		/// </summary>
		public void Start()
		{
			if (0 == _interval.TotalMilliseconds)
			{
				throw new InvalidOperationException("Set Elapsed property before calling Timer.Start().");
			}
			_timer = new Timer(OnElapsed, null, _interval, _interval);
		}

		/// <summary>
		/// Stops the PCLTimer.
		/// </summary>
		public void Stop()
		{
			_timer.Dispose();
		}

		/// <summary>
		/// Releases all resources.
		/// </summary>
		public void Dispose()
		{
			_timer.Dispose();
		}

		/// <summary>
		/// Invokes Elapsed event.
		/// </summary>
		/// <param name="state"></param>
		private void OnElapsed(object state)
		{
			if (null != _timer && null != Elapsed)
				Elapsed(this, EventArgs.Empty);
		}
	}
}
