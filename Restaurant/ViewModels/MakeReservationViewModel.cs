using Restaurant.Commands;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));

                ClearErrors(nameof(Name));

                if(!HasName)
                {
                    AddError("Name cannot be empty.", nameof(Name));
                }

                OnPropertyChanged(nameof(CanCreateReservation));
            }
        }

        private int _floorNumber = 1;
        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));

                ClearErrors(nameof(FloorNumber));

                if (!HasFloorNumberGreaterThanZero)
                {
                    AddError("Floor number must be greater than zero.", nameof(FloorNumber));
                }

                OnPropertyChanged(nameof(CanCreateReservation));
            }
        }

        private int _tableNumber;
        public int TableNumber
        {
            get
            {
                return _tableNumber;
            }
            set
            {
                _tableNumber = value;
                OnPropertyChanged(nameof(TableNumber));
            }
        }

        private DateTime _resDate = new DateTime(2021, 1, 8);
        public DateTime ResDate
        {
            get
            {
                return _resDate;
            }
            set
            {
                _resDate = value;
                OnPropertyChanged(nameof(ResDate));

                ClearErrors(nameof(ResDate));

                OnPropertyChanged(nameof(CanCreateReservation));
            }
        }

        public bool CanCreateReservation =>
            HasName &&
            HasFloorNumberGreaterThanZero &&
            !HasErrors;

        private bool HasName => !string.IsNullOrEmpty(Name);
        private bool HasFloorNumberGreaterThanZero => FloorNumber > 0;

        private string _submitErrorMessage;
        public string SubmitErrorMessage
        {
            get
            {
                return _submitErrorMessage;
            }
            set
            {
                _submitErrorMessage = value;
                OnPropertyChanged(nameof(SubmitErrorMessage));

                OnPropertyChanged(nameof(HasSubmitErrorMessage));
            }
        }

        public bool HasSubmitErrorMessage => !string.IsNullOrEmpty(SubmitErrorMessage);

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public MakeReservationViewModel(HotelStore hotelStore, NavigationService<ReservationListingViewModel> reservationViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
            CancelCommand = new NavigateCommand<ReservationListingViewModel>(reservationViewNavigationService);

            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }

            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);

            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
