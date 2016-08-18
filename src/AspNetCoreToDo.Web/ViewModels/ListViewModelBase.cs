namespace AspNetCoreToDo.Web.ViewModels
{
    using System.Collections.Generic;

    public abstract class ListViewModelBase<T>
    {
        public IEnumerable<T> Items { get; set; }

        public string NotificationMessage { get; set; }

        public bool ShowNotificationMessage => !string.IsNullOrEmpty(NotificationMessage);}
}
