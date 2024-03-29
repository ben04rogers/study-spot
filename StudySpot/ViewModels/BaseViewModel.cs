﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using StudySpot.Models;
using StudySpot.Services;

namespace StudySpot.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Command GoToNotifications { get; }
        // Default constructor
        public BaseViewModel()
        {
            // Top nav bar
            TopNavSubtitle = currDate; // Heading
            GoToNotifications = new Command(GoToNotificationsPage); // Profile button
        }
        async void GoToNotificationsPage()
        {
            await Shell.Current.GoToAsync("NotificationsPage");
        }

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IDataStore<TodaysClass> DataStore2 => DependencyService.Get<IDataStore<TodaysClass>>();
        public IDataStore<Message> DataStore3 => DependencyService.Get<IDataStore<Message>>();
        public IDataStore<Unit> DataStore4 => DependencyService.Get<IDataStore<Unit>>();
        public IDataStore<Announcement> DataStoreAnnouncement => DependencyService.Get<IDataStore<Announcement>>();
        public IDataStore<Grade> DataStoreAssessment => DependencyService.Get<IDataStore<Grade>>();
        public IDataStore<Notifications> DataStoreNotifications => DependencyService.Get<IDataStore<Notifications>>();


        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        // Property for Top Nav Bar
        public string currDate = DateTime.Today.ToString("D");
        protected string topNavSubtitle;
        public string TopNavSubtitle
        {
            get => topNavSubtitle;
            set
            {
                SetProperty(ref topNavSubtitle, value);
                OnPropertyChanged(nameof(TopNavSubtitle));
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
