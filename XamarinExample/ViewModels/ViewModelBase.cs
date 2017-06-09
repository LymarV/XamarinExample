using System;
using Prism.Mvvm;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using XamarinExample.Services.Network;
using XamarinExample.Exceptions;
using Polly;
using System.Net;
using Refit;
using Prism.Navigation;

namespace XamarinExample.ViewModels
{
	public abstract class ViewModelBase : BindableBase, INavigationAware
	{
		#region NotifyProperty IsLoading

		private bool _IsLoading;
		public bool IsLoading
		{
			get { return _IsLoading; }
			set { SetProperty (ref _IsLoading, value); }
		}

		#endregion

		#region NotifyProperty Exception

		private Exception _Exception;
		public Exception Exception
		{
			get { return _Exception; }
			set 
			{
				if (value != null)
				{
					ErrorText = GetErrorText (value);
					Debug.WriteLine (value);
				}

				SetProperty (ref _Exception, value); }
		}

		#endregion

		#region NotifyProperty ErrorText

		private string _ErrorText;
		public string ErrorText
		{
			get { return _ErrorText; }
			set { SetProperty (ref _ErrorText, value); }
		}

		#endregion

		CancellationTokenSource cancellationToken;

		protected bool isAppeared;
		protected bool doReloadOnAppear;

		public virtual void OnAppearing ()
		{
			isAppeared = true;

			if (doReloadOnAppear)
			{
				doReloadOnAppear = false;
				Reload ().ConfigureAwait (false);
			}
		}

		public virtual void OnDisappearing ()
		{
			isAppeared = false;

			CancelAll ();
		}

		public virtual Task ReloadOverride (CancellationToken cancelToken)
		{
			return Task.FromResult (true);
		}

		public void ReloadOnAppear ()
		{
			if (isAppeared)
			{
				Reload ().ConfigureAwait (false);
			}
			else
			{
				doReloadOnAppear = true;
			}
		}

		public async Task Reload ()
		{
			cancellationToken?.Cancel ();
			cancellationToken = new CancellationTokenSource ();

			await Policy
				.Handle<WebException>()
				.WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)))
				.ExecuteAsync(ReloadOverride, cancellationToken.Token)
				.WrapTaskDefault (this);
			
		}

		protected virtual string GetErrorText (Exception exc)
		{
			return exc.Message;
		}

		protected virtual void CancelAll ()
		{
			
		}

		Task CheckConnectivity ()
		{
			var connectivityService = App.Resolve<IConnectivityService> ();

			if (!connectivityService.IsNetworkAvailable)
			{
				var ex = new ConnectivityException ("No Internet Connection");
				Exception = ex;
				throw ex;
			}

			return Task.FromResult (false);
		}

		internal async Task WrapWithConnectivityCheck (Task task, bool throwOnFail = false)
		{
			try
			{
				await Policy
						.Handle<ConnectivityException> ()
						.WaitAndRetryAsync (retryCount: 3, sleepDurationProvider: attempt => TimeSpan.FromSeconds (3))
						.ExecuteAsync (CheckConnectivity);

				await task;
			}
			catch (Exception ex)
			{
				if (throwOnFail)
				{
					throw ex;
				}

				Exception = ex;
			}
		}

		internal async Task WrapWithExceptionHandling (Task task)
		{
			try
			{
				await task;

			}
			catch (OperationCanceledException)
			{
				// do nothing, this is an expected behaviour
			}
			catch (ApiException e) when (e.StatusCode == HttpStatusCode.Unauthorized)
			{
				await App.Logout ();
			}
			catch (Exception e)
			{
				Exception = e;
			}
		}

		internal async Task WrapWithLoading (Task task)
		{
			IsLoading = true;

			await task;

			IsLoading = false;
		}

		public virtual void OnNavigatedFrom (NavigationParameters parameters)
		{
			
		}

		public virtual void OnNavigatedTo (NavigationParameters parameters)
		{
			
		}

		public virtual void OnNavigatingTo (NavigationParameters parameters)
		{
			
		}
	}
}
