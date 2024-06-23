using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ModelWrapper.Extensions.Notifications;
using MudBlazor;
using System.Net;

namespace BAYSOFT.Presentations.APP.Blazor.Components.Helpers
{
	public static class ResponseNotificationsHelper
	{
		public static bool HandleNotifications<T>(this ApplicationResponse<T> response, [FromServices] ISnackbar Snackbar, bool notifyOnSuccess = true) where T : DomainEntity
		{
			if (response != null)
			{
				if (response.StatusCode == ((int)HttpStatusCode.OK))
				{
					if(notifyOnSuccess)
						Snackbar.Add(response.Message, Severity.Success);
					return true;
				}
				else
				{
					Snackbar.Add(response.Notifications.GetMessage(), Severity.Warning);
					// if(response.Notifications.HasRequest())
					//     foreach (var requestNotifications in response.Notifications.GetRequest().Values))
					//     {
					//         Snackbar.Add(requestNotifications);
					//     }
					// if(response.Notifications.HasEntity())
					//     foreach (var entityNotifications in ((string[])response.Notifications.GetDomain().Values))
					//     {
					//         Snackbar.Add(entityNotifications);
					//     }
					if (response.Notifications.HasDomain())
						foreach (var domainNotifications in response.Notifications.GetDomain())
						{
							Snackbar.Add(domainNotifications, Severity.Warning);
						}
				}
			}
			return false;
		}
	}
}
