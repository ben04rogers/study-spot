﻿using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Collections.ObjectModel;
using StudySpot.Models;

namespace StudySpot.ViewModels
{
    [QueryProperty("Email", "email")]
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<TodaysClass> TodaysClasses { get; set; }
        public Command GoToClasses { get; }
        public Command GoToMessages { get; }


        public HomePageViewModel()
        {
            // Test data
            SetupData();

            Title = "Home";

            GoToClasses = new Command(GoToClassesPage);
            GoToMessages = new Command(GoToMessagesPage);
        }

        async void GoToClassesPage()
        {
            await Shell.Current.GoToAsync("ClassesPage");
        }

        async void GoToMessagesPage()
        {
            await Shell.Current.GoToAsync("MessagesPage");
        }

        string email;
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, Uri.UnescapeDataString(value)); //MvvmHelpers Implementation
                OnPropertyChanged(nameof(Email));

            }
        }

        // Dummy Data to test with
        void SetupData()
        {
            TodaysClasses = new ObservableCollection<TodaysClass>()
            {
                new TodaysClass
                {
                    UnitCode = "CAB303",
                    Time = "9:00",
                    TimePeriod = "AM",
                    LessonType = "Online Workshop",
                    Platform = "Zoom ID: 937109249"
                },
                new TodaysClass
                {
                    UnitCode = "IAB330",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams"
                },
                new TodaysClass
                {
                    UnitCode = "IAB330",
                    Time = "11:00",
                    TimePeriod = "AM",
                    LessonType = "Online Tutorial",
                    Platform = "Microsoft Teams"
                }
            };
        }

    }
}
